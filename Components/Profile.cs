using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Components
{
    public class Profile:ViewComponent
    {
        public Profile()
        {

        }
        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}
