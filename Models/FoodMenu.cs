using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class FoodMenu
    {
        public int id { get; set; }
        public List<FoodItem> itemList { get; set; }
    }
}
