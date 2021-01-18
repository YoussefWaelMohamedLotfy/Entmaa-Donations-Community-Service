﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class DonationOnRequestConfiguration:EntityTypeConfiguration<DonationOnRequest>
    {
        public DonationOnRequestConfiguration()
        {

            Property(d => d.DonationToken).IsRequired();
            HasKey(d => new { d.ContibutorID, d.RequestID });
        }
    }
}