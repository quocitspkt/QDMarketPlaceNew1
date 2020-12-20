using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class AnnouncementUser 
    {
        public int Id { get; set; }
        
        //[Required]
        public string AnnouncementId { get; set; }

        public Guid UserId { get; set; }

        public bool? HasRead { get; set; }

        //[ForeignKey("AnnouncementId")]
        public Announcement Announcement { get; set; }
    }
}
