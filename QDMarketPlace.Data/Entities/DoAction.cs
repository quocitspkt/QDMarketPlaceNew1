using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class DoAction 
    {
        public int Id { get; set; }
        //[StringLength(50)]

        public string Code { get; set; }
        //[StringLength(50)]

        public string Name { get; set; }
        public ICollection<ActionInFunction> ActionInFunctions { get; set; }
    }
}
