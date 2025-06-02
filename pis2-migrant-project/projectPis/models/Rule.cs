using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPis.models
{
    public class Rule
    {
        public int RuleId { get; set; }
        public string Description { get; set; }
        public string Parameter { get; set; }
        public string CheckParameter { get; set; }
        public string CompOperator { get; set; }
    }
}
