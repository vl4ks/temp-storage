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
    public class AdminController
    {
        private readonly AccountService _accountService;
        private readonly ServiceManagementService _serviceManagementService;

        public AdminController(AccountService accountService, ServiceManagementService serviceManagementService)
        {
            _accountService = accountService;
            _serviceManagementService = serviceManagementService;
        }

        public Service CreateService(string name, string description, int period)
        {
            return _serviceManagementService.CreateService(name, description, period);
        }

        public void UpdateService(Service service)
        {
            _serviceManagementService.UpdateService(service);
        }

        public void AddRuleToService(Service service, Rule rule)
        {
            _serviceManagementService.AddRuleToService(service, rule);
        }

        public Account CreateAccount(Account account)
        {
            return _accountService.CreateAccount(account);
        }

        public void DeleteRule(Service service, int ruleId)
        {
            _serviceManagementService.DeleteRule(service, ruleId);
        }

        public AccountRole GetUserRole(Account account)
        {
            return _accountService.GetUserRole(account);
        }
    }
}
