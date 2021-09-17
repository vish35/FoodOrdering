using Foodordering.Models;
using Foodordering.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Controllers
{
    public class FoodMenuController : Controller
    {
        //  private IFoodMenu _foodmenu;
        private readonly IFoodItemRepo _foodItemRepo;

        //DI
        public FoodMenuController(IFoodItemRepo foodItemRepo)
        {
            _foodItemRepo = foodItemRepo;

        }
        public IActionResult Index()
        {
           var model=_foodItemRepo.allitems;
            return View(model);
        }
    }
}
