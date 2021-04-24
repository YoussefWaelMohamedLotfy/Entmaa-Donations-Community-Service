using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Core.Repositories
{
    public interface IContributorRepository : IRepository<Contributor>
    {
        Contributor GetContributorProfileCreation(int id);
        Contributor Login(string email, string password);
        Contributor GetContributorProfile(int id);
        Contributor GetContributorBadges(int id);
    }
}
