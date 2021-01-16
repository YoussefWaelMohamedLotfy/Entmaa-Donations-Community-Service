using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Entmaa_Web_Services.Core;

namespace Entmaa_Web_Services.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        // Repositories


        public UnitOfWork(MainContext context)
        {
            _context = context;


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