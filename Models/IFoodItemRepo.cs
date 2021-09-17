using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public interface IFoodItemRepo
    {
        IEnumerable<FoodItem> allitems { get; }
        FoodItem getfooditembyid(int id);
        IEnumerable<FoodItem> searcheditems(string searchedkey);
    }
}
