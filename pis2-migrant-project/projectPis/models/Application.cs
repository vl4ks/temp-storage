using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.enums;
using projectPis.models.accounts;

namespace projectPis.models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public ApplicationStatus Status { get; set; }
        public string Comment { get; set; }
        public DateTime SubDate { get; set; }
        public DateTime? ExecDate { get; set; }
        public User User { get; set; }
        public Service Service { get; set; }
        public GovernmentServant Servant { get; set; }
    }
}
