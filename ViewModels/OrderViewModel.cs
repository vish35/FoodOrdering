using Foodordering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.ViewModels
{
    public class OrderViewModel
    {
     
        public FoodItem foodItem { get; set; }
        public int quantity { get; set; }
        public DateTime orderedon { get; set; }
    }
}
