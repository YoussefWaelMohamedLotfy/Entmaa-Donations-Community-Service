using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Persistence.Initializers
{
    public class MainInitializerAlways : DropCreateDatabaseAlways<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            base.Seed(context);


        }
    }
}