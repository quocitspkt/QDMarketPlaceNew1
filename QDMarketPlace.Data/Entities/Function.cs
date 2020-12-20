﻿using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class Function 
    {
       
        public string Id { get; set; }
        //[Required]
        [StringLength(128)]
        public string Name { set; get; }

        //[Required]
        //[StringLength(250)]
        public string URL { set; get; }


        //[StringLength(128)]
        public string ParentId { set; get; }

        public string IconCss { get; set; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public ICollection<ActionInFunction> ActionInFunctions { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
