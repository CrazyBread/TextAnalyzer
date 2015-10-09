using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Connector.Redmine
{
    public static class Connector
    {
        public static List<Model.Issue> GetAllIssues()
        {
            List<Model.Issue> result = null;
            using(var db = new Model.dbEntities())
            {
                result = db.Issues.ToList();
            }
            return result;
        }
    }
}
