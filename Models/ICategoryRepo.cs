using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
   public interface ICategoryRepo
    {
        IEnumerable<MealType> AllCategories { get; }
    }
}
