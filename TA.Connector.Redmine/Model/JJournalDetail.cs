using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Connector.Redmine.Model
{
    public class JJournalDetail
    {
        public string property { set; get; }
        public string name { set; get; }
        public string old_value { set; get; }
        public string new_value { set; get; }
    }
}
