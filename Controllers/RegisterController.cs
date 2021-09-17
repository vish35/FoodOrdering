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
    public class RegisterController : Controller
    {
        private readonly IOrderRepo _orderRepo;
      //  private readonly ShoppingCart shoppingCart;

        //DI
        public RegisterController(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderRepo.AddOrder(order);

                return RedirectToAction("Checkout");
            }
            return View();
        }

        public ActionResult Checkout()
        {
            ViewBag.CheckoutMsg = "Thanks for you order. You'll soon receive the art & enjoy the painting adorning your space! ";
            return View();

        }
        public IActionResult MyOrder(string mailid)
        {
            List<PrevOrder> myorders=_orderRepo.myOrders(mailid);
            Dictionary<int, List<OrderViewModel>> list = _orderRepo.segOrders(myorders);
           
            return View(list);
        }
    }
}
