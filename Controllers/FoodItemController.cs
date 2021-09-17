using Foodordering.Models;
using Foodordering.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Controllers
{
    [Authorize]
    public class FoodItemController : Controller
    {
        private readonly IFoodItemRepo _foodItemRepo;
        private readonly ICategoryRepo _categoryRepo;
        public FoodItemController(IFoodItemRepo foodItemRepo, ICategoryRepo categoryRepo)
        {
            _foodItemRepo = foodItemRepo;
            _categoryRepo = categoryRepo;

        }
        public IActionResult Index(int mealid)
        {
            IEnumerable<FoodItem> items;
            string currentCategory;

            if (mealid == 0)
            {
                items = _foodItemRepo.allitems.OrderBy(p => p.id);
                currentCategory = "All Items";
            }
            else
            {
                items = _foodItemRepo.allitems.Where(p => p.mealType == mealid)
                    .OrderBy(p => p.id);
                currentCategory = _categoryRepo.AllCategories.FirstOrDefault(c => c.MealId == mealid)?.MealName;
            }
            return View(new FoodListViewModel
            {
                FoodItems = items,
                CurrentCategory = currentCategory
            });
           
        }
        public IActionResult Details(int id)
        {
            var fooditem = _foodItemRepo.getfooditembyid(id);
            if (fooditem == null)
            {
                return NotFound();
            }
            return View(fooditem);
        }
    }
}
