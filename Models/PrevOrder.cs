using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class PrevOrder
    {
       [Key]
        public string porder { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
       
        public int Itemid { get; set; }
        public int quantity { get; set; }
       
    }
}
