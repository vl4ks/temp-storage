using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPis.models.accounts
{
    public class Admin : Account
    {
        public List<Service> Services { get; set; } = new List<Service>();
    }

}
