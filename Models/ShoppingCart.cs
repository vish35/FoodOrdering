using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class ShoppingCart
    {
        private readonly Foodorderingdbcontext _foodorderingDbContext;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(Foodorderingdbcontext foodorderingDbContext)
        {
            _foodorderingDbContext = foodorderingDbContext;
        }

       public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems =_foodorderingDbContext.ShoppingCartItems.Where(s=>s.ShoppingCartId==ShoppingCartId
                ).Include(s => s.item).ToList();
        }

       
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<Foodorderingdbcontext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        internal decimal GetShoppingCartTotal()
        {
            var total = _foodorderingDbContext.ShoppingCartItems.Where(c => ShoppingCartId == ShoppingCartId)
                .Select(c => c.item.price * c.quantity).Sum();
            return (decimal)total;
        }

        public void AddToCart(FoodItem item)
        {
            var shoppingCartItem =
                _foodorderingDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.item.id == item.id && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    item = item,
                    quantity = 1
                };
                _foodorderingDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.quantity++;
            }
            _foodorderingDbContext.SaveChanges();
        }

        public void RemoveFromCart(FoodItem selectedItem)
        {

            _foodorderingDbContext.ShoppingCartItems.Remove(_foodorderingDbContext.ShoppingCartItems.Where(s=>s.item.id==selectedItem.id).FirstOrDefault());
            _foodorderingDbContext.SaveChanges();
        }
        public void ClearCart()
        {
            List<int> allitemsid = _foodorderingDbContext.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Select(x => x.ShoppingCartItemId).ToList();
            foreach (var item in allitemsid)
            {
                _foodorderingDbContext.ShoppingCartItems.Remove(_foodorderingDbContext.ShoppingCartItems.Where(s => s.ShoppingCartItemId == item).FirstOrDefault());
                _foodorderingDbContext.SaveChanges();
            }

        }
        public void EditItemQuantity(FoodItem selectedItem)
        {
            var cart = _foodorderingDbContext.ShoppingCartItems.FirstOrDefault(s => s.item.id == selectedItem.id);
            cart.quantity -= 1;
            if(cart.quantity==0)
            {
                _foodorderingDbContext.ShoppingCartItems.Remove(_foodorderingDbContext.ShoppingCartItems.Where(s => s.item.id == selectedItem.id).FirstOrDefault());
            }
            _foodorderingDbContext.SaveChanges();
            // _foodorderingDbContext.ShoppingCartItems.Update(ShoppingCartItems.Where(s=>s.item==selectedItem.id));
        }
        public void EditItemQuantityIncrease(FoodItem selectedItem)
        {
            var cart = _foodorderingDbContext.ShoppingCartItems.FirstOrDefault(s => s.item.id == selectedItem.id);
            cart.quantity += 1;
            
            _foodorderingDbContext.SaveChanges();
            // _foodorderingDbContext.ShoppingCartItems.Update(ShoppingCartItems.Where(s=>s.item==selectedItem.id));
        }
    }
}
