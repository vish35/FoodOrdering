﻿using Foodordering.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Components
{
    public class CategoryMenu:ViewComponent
    {
        private ICategoryRepo _categoryRepo;
        //DI
        public CategoryMenu(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;

        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepo.AllCategories.OrderBy(c => c.MealId);
            return View(categories);
        }
    }
}
