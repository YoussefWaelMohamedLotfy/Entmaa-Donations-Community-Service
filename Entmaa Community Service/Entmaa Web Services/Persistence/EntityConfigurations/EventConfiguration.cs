using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            HasKey(e => e.PostID);

            Property(e => e.Name).IsRequired();
            Property(e => e.MapLocation).IsRequired();

            HasRequired(e => e.Post).WithOptional(p => p.Event);

            HasMany(e => e.Volunteers).WithRequired(v => v.Event).HasForeignKey(v => v.EventID);
        }
    }
}