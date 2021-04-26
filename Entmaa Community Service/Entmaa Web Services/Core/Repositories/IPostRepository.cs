using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetPost(int id);
        IEnumerable<Post> GetOrganizationNews(int id);
    }
}
