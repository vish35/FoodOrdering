using Foodordering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Repository
{
    public interface IFoodMenu
    {
        public FoodMenu getAllFoodMenu();
    }
}
