using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly Foodorderingdbcontext _foodorderingDbContext;

        public CategoryRepo(Foodorderingdbcontext foodorderingDbContext)
        {
            _foodorderingDbContext = foodorderingDbContext;
        }

        public IEnumerable<MealType> AllCategories => _foodorderingDbContext.MealTypes;
  }
}
