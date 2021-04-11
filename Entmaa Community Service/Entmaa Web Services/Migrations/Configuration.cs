namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Models.Entmaa;

    internal sealed class Configuration : DbMigrationsConfiguration<Persistence.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Persistence.MainContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the context.DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
