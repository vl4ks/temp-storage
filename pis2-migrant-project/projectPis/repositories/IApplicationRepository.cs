using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.enums;
using projectPis.models;
using projectPis.models.accounts;

namespace projectPis.repositories
{
    public interface IApplicationRepository
    {
        void Save(Application application);
        Application FindById(int id);
        List<Application> FindByUser(User user);
        List<Application> FindByStatus(ApplicationStatus status);
        void UpdateStatus(int applicationId, ApplicationStatus status);
    }
}
