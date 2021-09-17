using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class FoodItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public Boolean isVeg { get; set; }
        public int mealType { get; set; }
        public string description { get; set; }
        public double price { get; set; }

        public string img_url { get; set; }

    }
}
