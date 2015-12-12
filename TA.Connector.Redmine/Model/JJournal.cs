using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Connector.Redmine.Model
{
    public class JJournal
    {
        public int id { set; get; }
        public DateTime created_on { set; get; }
        public JLink user { set; get; }
        public ICollection<JJournalDetail> details { set; get; }
    }
}
