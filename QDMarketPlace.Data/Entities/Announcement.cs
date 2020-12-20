﻿using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class Announcement 
    {
        public string Id { get; set; }

        //[Required]
        //[StringLength(250)]
        public string Title { set; get; }

        //[StringLength(250)]
        public string Content { set; get; }

        public Guid UserId { set; get; }

        //[ForeignKey("UserId")]
        //public virtual AppUser AppUser { get; set; }

        public ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public Status Status { set; get; }
    }
}
