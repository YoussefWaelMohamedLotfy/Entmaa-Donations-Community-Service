using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Dataset
{
    public class CommentDatasetDTO
    {
        public int ID { get; set; }

        public int PostID { get; set; }

        public int UserID { get; set; }

        public string Comment { get; set; }
    }
}