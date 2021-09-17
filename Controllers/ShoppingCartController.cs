using Foodordering.Models;
using Foodordering.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IFoodItemRepo _fooditemRepo;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IFoodItemRepo foodItemRepo, ShoppingCart shoppingCart)
        {
            _fooditemRepo = foodItemRepo;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
               
            };

            return View(shoppingCartViewModel);

        }

        public RedirectToActionResult AddToShoppingCart(int itemid)
        {
            var selectedItem = _fooditemRepo.allitems.FirstOrDefault(p => p.id == itemid);
               
            if (selectedItem != null)
            {
                _shoppingCart.AddToCart(selectedItem);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int itemid)
        {
            var selectedItem = _fooditemRepo.allitems.FirstOrDefault(p => p.id == itemid);
            if (selectedItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedItem);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult clearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }

        public RedirectToActionResult DecreaseEditQuantity(int itemid)
        {
            var selectedItem = _fooditemRepo.allitems.FirstOrDefault(p => p.id == itemid);
            if (selectedItem != null)
            {
                _shoppingCart.EditItemQuantity(selectedItem);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult IncreaseEditQuantity(int itemid)
        {
            var selectedItem = _fooditemRepo.allitems.FirstOrDefault(p => p.id == itemid);
            if (selectedItem != null)
            {
                _shoppingCart.EditItemQuantityIncrease(selectedItem);
            }
            return RedirectToAction("Index");
        }

    }
}
