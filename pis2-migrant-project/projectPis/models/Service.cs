using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPis.models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Period { get; set; }
        public List<Rule> Rules { get; set; } = new List<Rule>();
    }
}
