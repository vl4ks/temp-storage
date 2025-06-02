using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.enums;
using projectPis.models.accounts;
using projectPis.models;
using projectPis.services;

namespace projectPis.controllers
{
    public class UserController
    {
        private readonly AccountService _accountService;
        private readonly ApplicationProcessingService _applicationService;

        public UserController(AccountService accountService, ApplicationProcessingService applicationService)
        {
            _accountService = accountService;
            _applicationService = applicationService;
        }

        public User Register(string login, string password, string name, DateTime birthDate, string passport)
        {
            var user = new User
            {
                Login = login,
                Password = password,
                Role = AccountRole.USER,
                Name = name,
                BirthDate = birthDate,
                Passport = passport
            };
            return (User)_accountService.CreateAccount(user);
        }

        public User GetProfile(User user)
        {
            return user;
        }

        public Application SubmitApplication(User user, Service service)
        {
            return _accountService.SubmitApplication(user, service);
        }

        public List<Application> GetUserApplications(User user)
        {
            return _accountService.GetUserApplications(user);
        }
    }
}
