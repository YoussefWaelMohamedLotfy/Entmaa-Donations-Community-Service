using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Initializers
{
    public class MainInitializerAlways : DropCreateDatabaseAlways<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            context.UserTypes.Add(new UserType { Name = "Contributor" });
            context.UserTypes.Add(new UserType { ID = 1, Name = "Organization" });

            context.PostTypes.Add(new PostType { Name = "Donation" });
            context.PostTypes.Add(new PostType { ID = 1, Name = "LostOrFound" });

            context.Contributors.Add(new Contributor()
            {
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

            context.Contributors.Add(new Contributor()
            {
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

            context.Contributors.Add(c);



            base.Seed(context);
        }
    }
}