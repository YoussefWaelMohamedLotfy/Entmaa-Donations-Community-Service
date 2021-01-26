namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
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

            context.UserTypes.AddOrUpdate(new UserType { Name = "Contributor" });
            context.UserTypes.AddOrUpdate(new UserType { ID = 1, Name = "Organization" });

            context.PostTypes.AddOrUpdate(new PostType { Name = "Donation" });
            context.PostTypes.AddOrUpdate(new PostType { ID = 1, Name = "LostOrFound" });
        }
    }
}
