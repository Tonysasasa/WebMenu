using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<DishIngredients>().HasKey(di => new
            {
                di.DishId,
                di.IngredientID
            });

            modelBuilder.Entity<DishIngredients>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredients>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientID);
            
            modelBuilder.Entity<Dishes>().HasData(
                new Dishes { Id = 1, Name = "Pizza", Price = 10, ImageUrl = "https://ik.imagekit.io/smithfield/armour/4353bced-f940-00d0-8c6e-13a0a4a7f5c2/2ac60829-5178-4a6e-80cf-6ca43d862cee/Quick-and-Easy-Pepperoni-Pizza-700x700.jpeg?tr=w-1160,c-at_max,f-auto" }            
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce" },
                new Ingredient { Id = 2, Name = "Cheese" }
                );
            modelBuilder.Entity<DishIngredients>().HasData(
                new DishIngredients { DishId = 1, IngredientID = 1},
                new DishIngredients { DishId = 1, IngredientID = 2 }
                );


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredients> DishIngredients { get; set; }

    }
}
