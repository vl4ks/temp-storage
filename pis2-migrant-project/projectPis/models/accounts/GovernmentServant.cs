using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPis.models.accounts
{
    public class GovernmentServant : Account
    {
        public string Department { get; set; }
        public List<Application> ProcessedApplications { get; set; } = new List<Application>();
    }
}
