using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.enums;
using projectPis.models;
using projectPis.services;

namespace projectPis.controllers
{
    public class GovernmentServantController
    {
        private readonly ApplicationProcessingService _applicationService;

        public GovernmentServantController(ApplicationProcessingService applicationService)
        {
            _applicationService = applicationService;
        }

        public void SetStatus(int applicationId, enums.Action action, string comment = null)
        {
            _applicationService.ProcessApplication(applicationId, action, comment);
        }

        public void CompleteApplication(int applicationId, string comment)
        {
            _applicationService.CompleteApplication(applicationId, comment);
        }

        public List<Application> GetApplicationsByStatus(ApplicationStatus status)
        {
            return _applicationService.GetApplicationsByStatus(status);
        }

        public Application GetApplicationById(int id)
        {
            return _applicationService.GetApplicationById(id);
        }
    }
}
