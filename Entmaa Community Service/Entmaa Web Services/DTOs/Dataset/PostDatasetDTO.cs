using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Dataset
{
    public class PostDatasetDTO
    {
        public int ID { get; set; }

        public DateTime TimePosted { get; set; }

        public string Description { get; set; }

        public int PostedBy { get; set; }

        public byte PostTypeID { get; set; }
    }
}