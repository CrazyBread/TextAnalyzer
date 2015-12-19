using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Connector.Redmine
{
    public static class Connector
    {
        /// <summary>
        /// Возвращает список всех задач из редмайна.
        /// </summary>
        /// <returns></returns>
        public static List<Model.Issue> GetAllIssues()
        {
            List<Model.Issue> result = null;
            using(var db = new Model.dbEntities())
            {
                result = db.Issues.Include("Status").OrderByDescending(i => i.RedmineId).ToList();
            }
            return result;
        }

        /// <summary>
        /// Возвращает список всех статусов задач из редмайна.
        /// </summary>
        /// <returns></returns>
        public static List<Model.Facet> GetAllStatuses()
        {
            List<Model.Facet> result = null;
            using (var db = new Model.dbEntities())
            {
                result = db.Facets.Where(i => i.Group == "status").ToList();
            }
            return result;
        }
    }
}
