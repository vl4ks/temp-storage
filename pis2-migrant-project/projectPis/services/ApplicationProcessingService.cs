using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.enums;
using projectPis.models;
using projectPis.repositories;

namespace projectPis.services
{
    public class ApplicationProcessingService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationProcessingService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public void ProcessApplication(int applicationId, enums.Action action, string comment = null)
        {
            ApplicationStatus status;

            // Классический switch-case (работает в C# 7.3)
            switch (action)
            {
                case enums.Action.APPROVE:
                    status = ApplicationStatus.APPROVED;
                    break;
                case enums.Action.REQUEST_CHANGE:
                    status = ApplicationStatus.PENDING;
                    break;
                case enums.Action.REJECT:
                    status = ApplicationStatus.REJECTED;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }

            _applicationRepository.UpdateStatus(applicationId, status);

            if (!string.IsNullOrEmpty(comment))
            {
                var application = _applicationRepository.FindById(applicationId);
                application.Comment = comment;
            }
        }

        public void CompleteApplication(int applicationId, string comment)
        {
            _applicationRepository.UpdateStatus(applicationId, ApplicationStatus.COMPLETED);
            var application = _applicationRepository.FindById(applicationId);
            application.Comment = comment;
            application.ExecDate = DateTime.Now;
        }

        public List<Application> GetApplicationsByStatus(ApplicationStatus status)
        {
            return _applicationRepository.FindByStatus(status);
        }

        public Application GetApplicationById(int id)
        {
            return _applicationRepository.FindById(id);
        }
    }

}
