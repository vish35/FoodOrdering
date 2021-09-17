using Foodordering.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class OrderRepo:IOrderRepo
    {
        private readonly Foodorderingdbcontext _foodorderingDbContext;
        public string ShoppingCartId { get; set; }
        public OrderRepo(Foodorderingdbcontext foodorderingDbContext, IServiceProvider services)
        {
            _foodorderingDbContext = foodorderingDbContext;
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            ShoppingCartId = session.GetString("CartId");
        }
        public void AddOrder(Order order)
        {
          order.OrderTotal= (decimal)_foodorderingDbContext.ShoppingCartItems.Where(c => ShoppingCartId == ShoppingCartId)
                .Select(c => c.item.price * c.quantity).Sum();
            order.OrderPlaced = DateTime.Now;
            _foodorderingDbContext.Orders.Add(order);
           
            _foodorderingDbContext.SaveChanges();
          
            List<int> allitemsid = _foodorderingDbContext.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Select(x=>x.ShoppingCartItemId).ToList();
            foreach (var item in allitemsid)
            {
                var shoppingcartitem = _foodorderingDbContext.ShoppingCartItems.SingleOrDefault(x => x.ShoppingCartItemId == item);
                var itemid = _foodorderingDbContext.ShoppingCartItems.Where(x => x.ShoppingCartItemId == item).Select(x=>x.item.id).FirstOrDefault();
                var fooditem = _foodorderingDbContext.FoodItem.SingleOrDefault(x => x.id == itemid);
                var currentOrder = new PrevOrder
                {
                    porder= Guid.NewGuid().ToString(),
                    OrderId = order.OrderId,
                    Itemid = itemid,
                    quantity = shoppingcartitem.quantity
                };
                _foodorderingDbContext.PrevOrders.Add(currentOrder);
                _foodorderingDbContext.SaveChanges();
            }
            foreach (var item in allitemsid)
            {
                _foodorderingDbContext.ShoppingCartItems.Remove(_foodorderingDbContext.ShoppingCartItems.Where(s => s.ShoppingCartItemId==item).FirstOrDefault());
                _foodorderingDbContext.SaveChanges();
            }
        }
        public List<PrevOrder> myOrders(string mailid)
        {
            var orderid=_foodorderingDbContext.Orders.Where(x => x.Email == mailid).Select(x=>x.OrderId).ToList();
            HashSet<int> orderid1 = new HashSet<int>(orderid);
            List<PrevOrder> myorders = new List<PrevOrder>();
                foreach (var order in _foodorderingDbContext.PrevOrders)
            {
                if(orderid1.Contains(order.OrderId))
                {
                    myorders.Add(order);
                }
            }
    
            return myorders;
        }

        public Dictionary<int, List<OrderViewModel>> segOrders(List<PrevOrder> myorders)
        {
         
            Dictionary<int, List<OrderViewModel>> htable = new Dictionary<int, List<OrderViewModel>>();
            foreach (var item in myorders)
            {
                if(htable.ContainsKey(item.OrderId))
                {
                    htable[item.OrderId].Add(new OrderViewModel
                    {
                        foodItem = _foodorderingDbContext.FoodItem.SingleOrDefault(x => x.id == item.Itemid),
                        quantity = item.quantity,
                        orderedon = _foodorderingDbContext.Orders.Where(x => x.OrderId == item.OrderId).Select(x => x.OrderPlaced).Single()
                    }) ; 
                }
                else
                {
                    htable.Add(item.OrderId, new List<OrderViewModel> {
                    new OrderViewModel
                    {
                        foodItem = _foodorderingDbContext.FoodItem.SingleOrDefault(x => x.id == item.Itemid),
                        quantity = item.quantity,
                           orderedon = _foodorderingDbContext.Orders.Where(x => x.OrderId == item.OrderId).Select(x => x.OrderPlaced).Single()

                    }
                    });
                }
            }
           
            return htable;
        }
    }
}
