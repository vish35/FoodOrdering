using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class MealType
    {
        [Key]
        public int MealId { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
      //  public List<FoodItem> Items { get; set; }
        
    }
}
