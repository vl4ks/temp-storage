using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPis.models.accounts
{
    public class User : Account
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Purpose { get; set; }
        public string PhoneNumber { get; set; }
        public string Citizenship { get; set; }
        public string Passport { get; set; }
        public string Email { get; set; }
        public string Inn { get; set; }
        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
