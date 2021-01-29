using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class ReportedItem
    {
        public ReportedItem()
        {
            ReportedItemPhotos = new HashSet<ReportedItemPhoto>();
            Tags = new HashSet<Tag>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MapLocation { get; set; }

        public int CreatedBy { get; set; }

        public int ResolvedBy { get; set; }

        public bool IsFound { get; set; }

        public Contributor ContributorCreated { get; set; }

        public Contributor ContributorResolved { get; set; }

        public ICollection<ReportedItemPhoto> ReportedItemPhotos { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}