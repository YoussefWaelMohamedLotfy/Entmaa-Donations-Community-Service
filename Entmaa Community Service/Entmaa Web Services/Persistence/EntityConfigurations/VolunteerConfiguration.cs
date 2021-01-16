using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class VolunteerConfiguration : EntityTypeConfiguration<Volunteer>
    {
        public VolunteerConfiguration()
        {
            HasKey(v => new { v.ContributorID, v.EventID });
        }
    }
}