using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectPis.models;

namespace projectPis.repositories
{
    public interface IServiceRepository
    {
        void Save(Service service);
        List<Service> FindAll();
        Service FindByName(string name);
        Service FindById(int id);
    }
}
