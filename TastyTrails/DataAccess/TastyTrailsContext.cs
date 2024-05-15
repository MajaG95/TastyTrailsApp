using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TastyTrailsContext : DbContext
    {
        public TastyTrailsContext(DbContextOptions<TastyTrailsContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> FoodItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderMenuItem> OrderMenuItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant() { Id = 1, Name = "Restaurant_One", City = "Novi Sad", Country = "Serbia", Address = "Addr1", Currency = "RSD", Description = "Resraurant One" },
                new Restaurant() { Id = 2, Name = "Restaurant_Two", City = "Belgrade", Country = "Serbia", Address = "Addr2", Currency = "RSD", Description = "Resraurant Two" },
                new Restaurant() { Id = 3, Name = "Restaurant_Three", City = "Novi Sad", Country = "Serbia", Address = "Addr3", Currency = "RSD", Description = "Resraurant Three" }
                );
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem() { Id = 1, Name = "Pasta Carbonara", Description = "Pasta with white sauce, basil and parmesan", Price = 15, RestaurantId = 1 },
                new MenuItem() { Id = 2, Name = "Pasta Pesto", Description = "Pasta with pesto sauce, basil and parmesan", Price = 11, RestaurantId = 2 },
                new MenuItem() { Id = 3, Name = "Clasic Burger", Description = "Beef burger", Price = 30, RestaurantId = 3 },
                new MenuItem() { Id = 4, Name = "Chicken Salad", Description = "Salad with chicken", Price = 12, RestaurantId = 3 },
                new MenuItem() { Id = 5, Name = "Green Salad", Description = "Green Salad", Price = 10, RestaurantId = 2 },
                new MenuItem() { Id = 6, Name = "Pancakes", Description = "Pancakes with nutela", Price = 7, RestaurantId = 1 },
                new MenuItem() { Id = 7, Name = "CheeseBurger", Description = "Burger with chedar cheese", Price = 27, RestaurantId = 1 },
                new MenuItem() { Id = 8, Name = "Bacon Burger", Description = "Burger with bacon", Price = 35, RestaurantId = 2 },
                new MenuItem() { Id = 9, Name = "Chips", Description = "Chips", Price = 5, RestaurantId = 3 },
                new MenuItem() { Id = 10, Name = "Vege Burger", Description = "Vege burge", Price = 30, RestaurantId = 3 },
                new MenuItem() { Id = 11, Name = "Pizza Cappricciosa", Description = "Pizza Cappricciosa", Price = 21, RestaurantId = 2 },
                new MenuItem() { Id = 12, Name = "Pizza Margherita", Description = "Pizza with cheese", Price = 23, RestaurantId = 1 },
                new MenuItem() { Id = 13, Name = "Pizza Venezia", Description = "Pizza with olives", Price = 25, RestaurantId = 1 },
                new MenuItem() { Id = 14, Name = "Pizza Chicken", Description = "Pizza with chicken meat", Price = 19, RestaurantId = 1 },
                new MenuItem() { Id = 15, Name = "Pizza Quttro formaggi", Description = "4 types of cheese", Price = 20, RestaurantId = 3 },
                new MenuItem() { Id = 16, Name = "Pasta Bolognese", Description = "Pasta, Bolognese sauce, basil, parmesan", Price = 12, RestaurantId = 3 },
                new MenuItem() { Id = 17, Name = "Pasta Napolitana", Description = "Pasta, sauce, basil, parmesan", Price = 18, RestaurantId = 2 },
                new MenuItem() { Id = 18, Name = "Pasta Arrabbiata", Description = "Pasta, sauce, basil, parmesan", Price = 24, RestaurantId = 1 }
                );
            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo() { Id = 1, FirstName = "John", LastName = "Doe", Address = "Addr1", Email = "user1@test.com", Phone = "12345"},
                new UserInfo() { Id = 2, FirstName = "Sara", LastName = "Sara", Address = "Addr2", Email = "user2@test.com", Phone = "52678" },
                new UserInfo() { Id = 3, FirstName = "Jack", LastName = "Jack", Address = "Addr2", Email = "user2@test.com", Phone = "54954" }
                );
        }
    }
}
