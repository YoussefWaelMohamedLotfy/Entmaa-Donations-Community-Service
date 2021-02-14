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

            context.UserTypes.AddOrUpdate(new UserType { Name = "Contributor" });
            context.UserTypes.AddOrUpdate(new UserType { ID = 1, Name = "Organization" });

            context.PostTypes.AddOrUpdate(new PostType { Name = "Donation" });
            context.PostTypes.AddOrUpdate(new PostType { ID = 1, Name = "LostOrFound" });

            context.Contributors.AddOrUpdate(new Contributor()
            {
                ID = 1,
                Name = "Mahmoud Samir",
                Email = "mahmoudsamir@gmail.com",
                Password = "354421das",
                Description = "",
                Gender = "Male",
                FirebaseToken = "",
                UserTypeID = 0,
                BirthDate = new DateTime(1997, 4, 12),
                DateJoined = new DateTime(2002, 5, 2),
            });

            context.Contributors.AddOrUpdate(new Contributor()
            {
                ID = 3,
                Name = "Ahmed Khaled",
                Email = "ahmedkhaled@gmail.com",
                Password = "12348416315",
                Description = "Love Volunteering",
                Gender = "Male",
                FirebaseToken = "",
                UserTypeID = 0,
                BirthDate = new DateTime(1994, 5, 25),
                DateJoined = new DateTime(2002, 4, 2),
            });

            Contributor c = new Contributor()
            {
                ID = 4,
                Name = "Sara Waleed",
                Email = "sarawaleed@gmail.com",
                Password = "kbqwe2312",
                Description = "Volunteering, Resala member.",
                Gender = "Female",
                FirebaseToken = "",
                UserTypeID = 0,
                BirthDate = new DateTime(1991, 3, 14),
                DateJoined = new DateTime(2005, 1, 8),
            };

            context.Contributors.AddOrUpdate(c);

            context.Contributors.AddOrUpdate(new Contributor()
            {
                ID = 8,
                Name = "Nader Abdallah",
                Email = "naderabdallah@gmail.com",
                Password = "19244142",
                Description = "",
                Gender = "Male",
                FirebaseToken = "",
                UserTypeID = 0,
                BirthDate = new DateTime(1996, 2, 5),
                DateJoined = new DateTime(2002, 4, 2),
            });

            context.Organizations.AddOrUpdate(new Organization() 
            {
                ID = 9,
                Name = "Resala",
                Email = "resala@gmail.com",
                Password = "41324451",
                Description = "",
                FirebaseToken = "",
                UserTypeID = 1,
                DateJoined = new DateTime(1999, 4, 12),
                Rating = 4.5f,
                FawryToken = "",
                FoundedDate = new DateTime(2000, 4, 8),
                IsApproved = false,
            });

            context.Organizations.AddOrUpdate(new Organization()
            {
                ID = 10,
                Name = "Dar El-Orman",
                Email = "darelorman@gmail.com",
                Password = "109471084614",
                Description = "Founded in 2000, we help poor people",
                FirebaseToken = "",
                UserTypeID = 1,
                DateJoined = new DateTime(1999, 4, 12),
                Rating = 4.3f,
                FawryToken = "",
                FoundedDate = new DateTime(2000, 4, 8),
                IsApproved = true,
            });

            context.Organizations.AddOrUpdate(new Organization()
            {
                ID = 12,
                Name = "Mersal",
                Email = "mersal@gmail.com",
                Password = "f3q1dqw5d4q",
                Description = "",
                FirebaseToken = "",
                UserTypeID = 1,
                DateJoined = new DateTime(2019, 4, 12),
                Rating = 4.0f,
                FawryToken = "",
                FoundedDate = new DateTime(2012, 4, 8),
                IsApproved = false,
            });
        }
    }
}
