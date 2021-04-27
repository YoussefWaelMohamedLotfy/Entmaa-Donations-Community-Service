using Entmaa_Web_Services.Models.Entmaa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entmaa_Web_Services.Core.Repositories
{
    public interface IOrganizationRepository: IRepository<Organization>
    {
        Organization GetOrganization(int id);
        IEnumerable<Organization> GetAllOrganizations();

        Organization ModifyOrganization(int id);
        Organization Login(string email, string password);
        

    }
}
