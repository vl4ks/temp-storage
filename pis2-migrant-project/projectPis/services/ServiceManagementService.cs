using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.models;
using projectPis.repositories;

namespace projectPis.services
{
    public class ServiceManagementService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceManagementService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Service CreateService(string name, string description, int period)
        {
            var service = new Service
            {
                Name = name,
                Description = description,
                Period = period
            };
            _serviceRepository.Save(service);
            return service;
        }

        public void AddRuleToService(Service service, Rule rule)
        {
            service.Rules.Add(rule);
            _serviceRepository.Save(service);
        }

        public Service GetServiceById(int id)
        {
            return _serviceRepository.FindById(id);
        }

        public void UpdateService(Service service)
        {
            _serviceRepository.Save(service);
        }

        public void DeleteRule(Service service, int ruleId)
        {
            var rule = service.Rules.FirstOrDefault(r => r.RuleId == ruleId);
            if (rule != null)
            {
                service.Rules.Remove(rule);
                _serviceRepository.Save(service);
            }
        }
    }
}
