using Foodordering.Models;
using Foodordering.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Services
{
    public class FoodMenuService :IFoodMenu
    {
        FoodMenu _foodMenu;
       public FoodMenuService( )
        {

            _foodMenu = new FoodMenu { id=1,
               itemList=new List<FoodItem>
                {
                new FoodItem{id=1,name="pizza",isVeg=true,mealType=1,description="This is cheese pizza",price=499},
                new FoodItem{id=2,name="burger",isVeg=true,mealType=2,description="This is cheese burger",price=199}

                }
            };
        }
        public FoodMenu getAllFoodMenu()
        {
            return _foodMenu;
        }

    }
}
