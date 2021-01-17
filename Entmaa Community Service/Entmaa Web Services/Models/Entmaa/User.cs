using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public abstract class User
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTime DateJoined { get; set; }

        public int ProfilePhotoID { get; set; }

        public int CoverPhotoID { get; set; }

        public string FirebaseToken { get; set; }
        
        public byte UserTypeID { get; set; }

        public UserType UserType { get; set; }

        public ICollection<Post> PostsReactedTo { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<UserLocation> Locations { get; set; }

        public ICollection<UserPhoneNumber> PhoneNumbers { get; set; }
    }

    public class UserType
    {
        public byte ID { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }

    public class UserPhoneNumber
    {
        public string PhoneNumber { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }
    }
}