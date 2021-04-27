using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public PostRepository(MainContext context) : base(context)
        {

        }

        public Post GetPost(int id)
        {
            return MainContext.Posts
                .Include(p => p.Tags)
                .Include(p => p.UsersReacted)
                .SingleOrDefault(p => p.ID == id);
        }

        public IEnumerable<Post> GetOrganizationNews(int id)
        {
            return MainContext.Posts
                .Include(p => p.Organization)
                .Include(p => p.PostComments)
                .Include(p => p.UsersReacted)
                .Include(p => p.Tags)
                .Where(p => p.PostedBy == id)
                .ToList();
        }
    }
}