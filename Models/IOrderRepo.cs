using Foodordering.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public interface IOrderRepo
    {
        public void AddOrder(Order order);
        public List<PrevOrder> myOrders(string mailid);
        public Dictionary<int, List<OrderViewModel>> segOrders(List<PrevOrder> myorders);
    }
        
}
