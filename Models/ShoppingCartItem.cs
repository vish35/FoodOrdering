using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public FoodItem item { get; set; }
        public int quantity { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
