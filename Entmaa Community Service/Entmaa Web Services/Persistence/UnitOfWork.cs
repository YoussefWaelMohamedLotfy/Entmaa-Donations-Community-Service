using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Persistence.Repositories;

namespace Entmaa_Web_Services.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        // Repositories
        public IContributorRepository Contributors { get; private set; }
        public IOrganizationRepository Organizations { get; private set; }
        public IBadgeRepository Badges { get; private set; }
        public IPostRepository Posts { get; private set; }

        public UnitOfWork(MainContext context)
        {
            _context = context;

            Contributors = new ContributorRepository(_context);
            Organizations = new OrganizationRepository(_context);
            Badges = new BadgeRepository(_context);
            Posts = new PostRepository(_context);
        }

        public int CompleteWork()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteWorkAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}