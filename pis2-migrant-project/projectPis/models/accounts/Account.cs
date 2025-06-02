using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.enums;

namespace projectPis.models.accounts
{
    public abstract class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public AccountRole Role { get; set; }
    }
}
