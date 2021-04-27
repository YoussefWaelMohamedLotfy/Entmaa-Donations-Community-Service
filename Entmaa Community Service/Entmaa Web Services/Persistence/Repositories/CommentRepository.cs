using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class CommentRepository : Repository<PostComment>, ICommentRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public CommentRepository(MainContext context) : base(context)
        {

        }


    }
}