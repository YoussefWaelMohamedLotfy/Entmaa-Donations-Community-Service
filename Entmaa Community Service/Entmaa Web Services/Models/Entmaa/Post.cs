﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Post
    {
        public int ID { get; set; }
        
        public DateTime TimePosted { get; set; }
        
        public string Description { get; set; }
        
        public int PostedBy { get; set; }
        
        public byte PostTypeID { get; set; }

        public PostType PostType { get; set; }

        public Organization Organization { get; set; }

        public Event Event { get; set; }

        public DonationRequest DonationRequest { get; set; }

        public ICollection<User> UsersReacted { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<PostPhoto> PostPhotos { get; set; }

        public ICollection<PostComment> PostComments { get; set; }


    }

    public class PostType
    {
        public byte ID { get; set; }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}