using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.enums;
using projectPis.models.accounts;
using projectPis.models;
using projectPis.repositories;

namespace projectPis.services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IApplicationRepository _applicationRepository;

        public AccountService(IAccountRepository accountRepository, IApplicationRepository applicationRepository)
        {
            _accountRepository = accountRepository;
            _applicationRepository = applicationRepository;
        }

        public Application SubmitApplication(User user, Service service)
        {
            var application = new Application
            {
                User = user,
                Service = service,
                Status = ApplicationStatus.PENDING,
                SubDate = DateTime.Now
            };
            _applicationRepository.Save(application);
            return application;
        }

        public void UpdateProfile(User user)
        {
            _accountRepository.Save(user);
        }

        public List<Application> GetUserApplications(User user)
        {
            return _applicationRepository.FindByUser(user);
        }

        public Account CreateAccount(Account account)
        {
            _accountRepository.Save(account);
            return account;
        }

        public Account Authenticate(string login, string password)
        {
            var account = _accountRepository.FindByLogin(login);
            return account != null && account.Password == password ? account : null;
        }

        public AccountRole GetUserRole(Account account)
        {
            return account.Role;
        }
    }
}
