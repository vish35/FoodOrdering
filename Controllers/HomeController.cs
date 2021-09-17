using Foodordering.Models;
using Foodordering.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodItemRepo _foodItemRepo;

        //DI
        public HomeController(IFoodItemRepo foodItemRepo)
        {
            _foodItemRepo = foodItemRepo;

        }
        public IActionResult Index()
        {
           
            var foodListViewModel = new FoodListViewModel
            {
                FoodItems = _foodItemRepo.allitems
        };
            return View(foodListViewModel);
        }
        public IActionResult Search(string searchstr)
        {
            var foodListViewModel = new FoodListViewModel
            {
                FoodItems = _foodItemRepo.searcheditems(searchstr)
            };
            return View(foodListViewModel);
        }
    }
}
