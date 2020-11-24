using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}