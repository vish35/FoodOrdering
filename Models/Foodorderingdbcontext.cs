using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class Foodorderingdbcontext :DbContext
    {
        public Foodorderingdbcontext(DbContextOptions<Foodorderingdbcontext> options):base(options)
        {

        }
        public DbSet<FoodItem> FoodItem { get; set; }

        public DbSet<MealType> MealTypes{ get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PrevOrder> PrevOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealType>().HasData(new MealType { MealId = 1, MealName = "BRUNCH", Description = "" });
            modelBuilder.Entity<MealType>().HasData(new MealType { MealId = 2, MealName = "ELEVENSES", Description = "" });
            modelBuilder.Entity<MealType>().HasData(new MealType { MealId = 3, MealName = "LUNCH", Description = "" });
            modelBuilder.Entity<MealType>().HasData(new MealType { MealId = 4, MealName = "DINNER", Description = "" });
            modelBuilder.Entity<MealType>().HasData(new MealType { MealId = 5, MealName = "SUPPER", Description = "" });
            modelBuilder.Entity<MealType>().HasData(new MealType { MealId = 6, MealName = "AFTERNOON_TEA", Description = "" });
            modelBuilder.Entity<MealType>().HasData(new MealType { MealId = 7, MealName = "HIGH_TEA", Description = "" });
           

            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { id = 1, name = "pizza", isVeg = true, mealType = 1, description = "This is cheese pizza", price = 499, img_url= "C:\\Users\\Vishakha.Karimungi\\OneDrive - MINDBODY, Inc\\Documents\\Food_images" });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { id = 2, name = "burger", isVeg = true, mealType = 2, description = "This is cheese burger", price = 199 });
            modelBuilder.Entity<User>().ToTable("User");
          
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<ShoppingCartItem>().ToTable("ShoppingCartItem");
            modelBuilder.Entity<Order>().ToTable("Order");
           // modelBuilder.Entity<PrevOrder>().HasNoKey();
            //modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCart");








            /*    public int MealId { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<FoodItem> items { get; set; }*/
            /*BREAKFAST,
        BRUNCH,
        ELEVENSES,
        LUNCH,
        DINNER,
        SUPPER,
        AFTERNOON_TEA,
        HIGH_TEA*/
        }



    }
}
