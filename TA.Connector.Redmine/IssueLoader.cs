using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TA.Connector.Redmine
{
    public class IssueLoader
    {
        private RedmineConfigurator _configurator;

        public IssueLoader(RedmineConfigurator configurator)
        {
            _configurator = configurator;
        }

        public void Run()
        {
            var db = new Model.dbEntities();

            IDictionary<int, DateTime?> issuesCache = db.Issues.ToDictionary(i => i.RedmineId, j => j.Updated);
            IList<Model.Facet> facetsCache = db.Facets.ToList();

            int totalCount = 1;
            int limit = 100;
            for (int i = 0; i < totalCount; i += 100)
            {
                var url = string.Format("{0}/issues.json?key={1}&limit={2}&offset={3}&status_id=*", _configurator.Link, _configurator.Key, limit, i);
                var json = GetStringFromUrl(url);
                var jResult = JsonConvert.DeserializeObject<Model.JIssueMultiply>(json);
                totalCount = jResult.total_count;
                limit = jResult.limit;

                foreach (var item in jResult.issues)
                {
                    if (issuesCache.ContainsKey(item.id) && issuesCache[item.id].HasValue && issuesCache[item.id].Value >= item.updated_on)
                        continue;

                    var issueItem = (issuesCache.ContainsKey(item.id)) ? db.Issues.First(j => j.RedmineId == item.id) : new Model.Issue() { RedmineId = item.id, Created = item.created_on };
                    issueItem.Updated = item.updated_on;
                    issueItem.Subject = item.subject;
                    issueItem.Description = item.description;
                    issueItem.StatusId = GetFacetId("status", item.status, facetsCache);
                    issueItem.TrackerId = GetFacetId("tracker", item.tracker, facetsCache);
                    issueItem.PriorityId = GetFacetId("priority", item.priority, facetsCache);
                    issueItem.ProjectId = GetFacetId("project", item.project, facetsCache);
                    if (item.assigned_to != null)
                        issueItem.AssigneeId = GetFacetId("user", item.assigned_to, facetsCache);

                    if (db.Entry(issueItem).State == System.Data.Entity.EntityState.Detached)
                        db.Issues.Add(issueItem);
                    if (!issuesCache.ContainsKey(item.id))
                        issuesCache.Add(item.id, item.updated_on);

                    Console.WriteLine("Issue #{0} added!", item.id);
                }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("{0} issues synchronized", limit);
            }
            Console.WriteLine("Synchronize completed");
        }

        public void RunJournals()
        {
            var closedTasks = new string[] { "Сделана", "Отклонена" };
            var db = new Model.dbEntities();

            var closedIssues = db.Issues.Include("Status").Where(i => closedTasks.Contains(i.Status.Name)).Select(i => new { i.Id, i.RedmineId }).ToList();
            var alreadySynchronized = db.Journals.GroupBy(i => i.IssueId, (i, j) => i).ToList();
            var openedIssues = db.Issues.Include("Status").Where(i => !closedTasks.Contains(i.Status.Name)).Select(i => new { i.Id, i.RedmineId }).ToList();
            var needSynchronized = closedIssues.Except(closedIssues.Where(i => alreadySynchronized.Contains(i.Id))).Union(openedIssues);

            IList<Model.Facet> facetsCache = db.Facets.ToList();
            IList<Model.JournalFacet> journalFacetsCache = db.JournalFacets.ToList();

            foreach (var issue in needSynchronized.OrderByDescending(i => i.RedmineId))
            {
                try
                {
                    var loadedJournals = db.Journals.Where(i => i.IssueId == issue.Id).Select(i => i.RedmineId).ToList();
                    var url = string.Format("{0}/issues/{1}.json?key={2}&include=journals", _configurator.Link, issue.RedmineId, _configurator.Key);
                    var json = GetStringFromUrl(url);
                    var jResult = JsonConvert.DeserializeObject<Model.JIssueSingle>(json);

                    if (jResult == null || jResult.issue == null || jResult.issue.journals == null || !jResult.issue.journals.Any())
                        continue;

                    foreach (var journal in jResult.issue.journals)
                    {
                        if (loadedJournals.Contains(journal.id))
                            continue;

                        var journalItem = new Model.Journal() { IssueId = issue.Id, RedmineId = journal.id, Date = journal.created_on, Created = DateTime.Now };
                        if (journal.user != null)
                            journalItem.AuthorId = GetFacetId("user", journal.user, facetsCache);
                        db.Journals.Add(journalItem);

                        foreach (var jDetails in journal.details)
                        {
                            var jDetailsItem = new Model.JournalDetail() { Journal = journalItem, OldValue = jDetails.old_value, NewValue = jDetails.new_value };
                            jDetailsItem.PropertyId = GetJournalFacetId(jDetails, journalFacetsCache);
                            db.JournalDetails.Add(jDetailsItem);
                        }
                    }

                    db.SaveChanges();
                    db.Dispose();
                    db = new Model.dbEntities();
                    Console.WriteLine("Journal for issue #{0} synchronized", issue.RedmineId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while synchronizinging journals for issue #{0}: {1}", issue.RedmineId, ex.Message);
                }
            }

            Console.WriteLine("Synchronize completed");
        }

        private int GetFacetId(string group, Model.JLink item, IList<Model.Facet> facetsCache)
        {
            if (item == null)
                return -1;

            var cacheItem = facetsCache.FirstOrDefault(i => i.Group == group && i.RedmineId == item.id);
            if (cacheItem != null)
                return cacheItem.Id;

            using (var db = new Model.dbEntities())
            {
                var facetItem = new Model.Facet() { Group = group, RedmineId = item.id, Name = item.name };
                db.Facets.Add(facetItem);
                db.SaveChanges();
                facetsCache.Add(facetItem);
                return facetItem.Id;
            }
        }

        private int GetJournalFacetId(Model.JJournalDetail item, IList<Model.JournalFacet> facetsCache)
        {
            if (item == null)
                return -1;

            var cacheItem = facetsCache.FirstOrDefault(i => i.Property == item.property && i.Name == item.name);
            if (cacheItem != null)
                return cacheItem.Id;

            using (var db = new Model.dbEntities())
            {
                var facetItem = new Model.JournalFacet() { Property = item.property, Name = item.name, Created = DateTime.Now };
                db.JournalFacets.Add(facetItem);
                db.SaveChanges();
                facetsCache.Add(facetItem);
                return facetItem.Id;
            }
        }

        private string GetStringFromUrl(string url)
        {
            string s = string.Empty;
            using (WebClient client = new WebClient())
            {
                s = client.DownloadString(url);
            }
            return s;
        }
    }
}
