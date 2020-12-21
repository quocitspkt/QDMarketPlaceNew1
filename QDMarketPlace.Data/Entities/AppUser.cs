using Microsoft.AspNetCore.Identity;
using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    public class AppUser:IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Avatar { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<FeedBack> FeedBacks { get; set; }
        public ICollection<Shop> Shops { get; set; }
        public ICollection<Post> Posts { get; set; }
        
    }
}
