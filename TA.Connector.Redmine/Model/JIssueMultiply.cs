using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Connector.Redmine.Model
{
    public class JIssueMultiply
    {
        public int total_count { set; get; }
        public ICollection<JIssue> issues { set; get; }
        public int limit { set; get; }
        public int offset { set; get; }
    }
}
