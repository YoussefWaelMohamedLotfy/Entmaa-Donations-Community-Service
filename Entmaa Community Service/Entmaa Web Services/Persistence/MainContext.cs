using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Persistence
{
    public class MainContext : DbContext
    {
        

        public MainContext() : base("name=EntmaaConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // To be removed
            base.OnModelCreating(modelBuilder);
        }
    }
}