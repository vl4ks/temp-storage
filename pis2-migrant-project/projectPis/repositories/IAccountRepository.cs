using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.enums;
using projectPis.models.accounts;

namespace projectPis.repositories
{
    public interface IAccountRepository
    {
        void Save(Account account);
        Account FindById(int id);
        Account FindByLogin(string login);
        List<Account> FindAll();
        void Delete(int id);
        List<Account> FindByRole(AccountRole role);
    }
}
