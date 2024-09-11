using ITIFinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIFinalProject.Context
{
    public class MyContext:DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;DataBase=test30;Trusted_Connection=true;Encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _Users = new List<User>()
            {
                new User{Id = 1, FirstName = "Omar", LastName = "Ali", Email = "@gamil.com",Password = 1234},
                new User{Id = 2, FirstName = "Mohamed", LastName = "Omar", Email = "@gamil.com",Password = 8374},
                new User{Id = 3, FirstName = "Esraa", LastName = "Ahmed", Email = "@gamil.com",Password = 9237},
                new User{Id = 4, FirstName = "Hoda", LastName = "Abdelrahman", Email = "@gamil.com",Password = 1754},
                new User{Id = 5, FirstName = "Menna", LastName = "Hamza", Email = "@gamil.com",Password = 9017},
                new User{Id = 6, FirstName = "Kareem", LastName = "Bahaa", Email = "@gamil.com",Password = 8692}
            };

            modelBuilder.Entity<User>().HasData(_Users);

            var _Categories = new List<Category>()
            {
               new Category{Id=1, Name="Electronics", Description="Devices and gadgets" },
               new Category{Id=2, Name="Clothing", Description="Apparel and accessories" },
               new Category{Id=3, Name="Home & Kitchen", Description="Furniture and kitchenware" },
               new Category{Id=4, Name="Books", Description="Various genres and authors" }
            };

            modelBuilder.Entity<Category>().HasData(_Categories);

            var _Products = new List<Product>()
            {
                new Product{Id=101, Title="Smartphone", Price=699.99,
                    Description="Latest model with high resolution camera",
                    Quantity=50, ImagePath="smartphone.jpg" , CategoryId = 1},

                new Product{Id=102, Title="Bluetooth Headphones", Price=89.99,
                    Description="Noise-cancelling over-ear headphones",
                    Quantity=150, ImagePath="bluetooth_headphones.jpg" , CategoryId = 2 },

                new Product{Id=201, Title="Leather Jacket", Price=129.99,
                    Description="Stylish leather jacket for winter",
                    Quantity=30, ImagePath="leather_jacket.jpg" , CategoryId = 3 },

                new Product{Id=202, Title="Running Shoes", Price=79.99,
                    Description="Comfortable running shoes with good support",
                    Quantity=100, ImagePath="running_shoes.jpg", CategoryId = 4},
            };

            modelBuilder.Entity<Product>().HasData(_Products);
        }
    }
}
