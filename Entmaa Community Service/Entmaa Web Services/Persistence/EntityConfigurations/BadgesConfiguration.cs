﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class BadgesConfiguration:EntityTypeConfiguration<Badge>
    {
       public BadgesConfiguration()
        {
            Property(b => b.Name).IsRequired();
        }
    }
}