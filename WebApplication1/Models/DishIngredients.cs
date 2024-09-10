using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DishIngredients
    {
        public int DishId { get; set; }
        public Dishes Dish { get; set; }
        public int IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
