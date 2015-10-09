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
            IDictionary<int, string> issuesCache = db.Issues.ToDictionary(i => i.RedmineId, j => string.Empty);
            IList<Model.Facet> facetsCache = db.Facets.ToList();

            int totalCount = 1;
            int limit = 100;
            for (int i = 0; i < totalCount; i += 100)
            {
                var url = string.Format("{0}/issues.json?key={1}&limit={2}&offset={3}&status_id=closed", _configurator.Link, _configurator.Key, limit, i);
                var json = GetStringFromUrl(url);
                var jResult = JsonConvert.DeserializeObject<Model.JIssueResponse>(json);
                totalCount = jResult.total_count;
                limit = jResult.limit;

                foreach (var item in jResult.issues)
                {
                    if (issuesCache.ContainsKey(item.id))
                        continue;

                    var issueItem = new Model.Issue() { RedmineId = item.id, Created = item.created_on, Subject = item.subject, Description = item.description };

                    issueItem.StatusId = GetFacetId("status", item.status, facetsCache);
                    issueItem.TrackerId = GetFacetId("tracker", item.tracker, facetsCache);
                    issueItem.PriorityId = GetFacetId("priority", item.priority, facetsCache);
                    issueItem.ProjectId = GetFacetId("project", item.project, facetsCache);
                    if (item.assigned_to != null)
                        issueItem.AuthorId = GetFacetId("assigned_to", item.assigned_to, facetsCache);

                    db.Issues.Add(issueItem);
                    issuesCache.Add(item.id, string.Empty);

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
