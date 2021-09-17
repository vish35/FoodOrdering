using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class FoodItemRepo:IFoodItemRepo
    {
        private readonly Foodorderingdbcontext _foodOrderingDbContext;

        public FoodItemRepo(Foodorderingdbcontext foodOrderingDbContext)
        {
            _foodOrderingDbContext = foodOrderingDbContext;
        }


        public IEnumerable<FoodItem> allitems
        {
            get
            {
                return _foodOrderingDbContext.FoodItem;
            }
        }

        public FoodItem getfooditembyid(int id)
        {
            return _foodOrderingDbContext.FoodItem.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<FoodItem> searcheditems(string searchedkey)
        {
            if(searchedkey==null)
            {
                return _foodOrderingDbContext.FoodItem.ToList();
            }
            IEnumerable<FoodItem>result= _foodOrderingDbContext.FoodItem.Where(x => x.name.Contains(searchedkey));

                return result;
        }
    }
}
