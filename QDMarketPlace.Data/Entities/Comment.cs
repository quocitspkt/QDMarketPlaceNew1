using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class Comment 
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Name { get; set; }

        //[StringLength(50)]

        public string Email { get; set; }

        //[StringLength(50)]

        public string Phone { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        public int Report { get; set; }

        public int PostId { get; set; }

        //[ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
