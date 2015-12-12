using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Connector.Redmine.Model
{
    public class JIssue
    {
        public int id { set; get; }
        public JLink project { set; get; }
        public JLink status { set; get; }
        public JLink tracker { set; get; }
        public JLink assigned_to { set; get; }
        public JLink priority { set; get; }
        public string subject { set; get; }
        public string description { set; get; }
        public DateTime created_on { set; get; }
        public ICollection<JJournal> journals { set; get; }
    }
}
