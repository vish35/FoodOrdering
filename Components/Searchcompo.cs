using Foodordering.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Components
{
    public class Searchcompo:ViewComponent
    {
        private IFoodItemRepo _foodItemRepo;
        //DI
        public Searchcompo(IFoodItemRepo foodItemRepo)
        {
            _foodItemRepo = foodItemRepo;

        }
        public IViewComponentResult Invoke()
        {
           
          
                return View();
           
        }
        //public IActionResult Search(Searchkey searchkey)
        //{
        //    var model = _foodItemRepo.searcheditems(searchkey.str);
        //    return View(model);
        //}
    }
}
