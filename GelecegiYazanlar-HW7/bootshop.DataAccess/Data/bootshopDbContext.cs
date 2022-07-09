using bootshop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootshop.DataAccess.Data
{
    public class bootshopDbContext : DbContext
    {
        public bootshopDbContext(DbContextOptions<bootshopDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryID)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Phones"
                },
                new Category
                {
                    Id = 2,
                    Name = "Laptops"
                },
                new Category
                {
                    Id = 3,
                    Name = "TVs"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                        new Product
                        {
                            Id = 1,
                            Name = "IPhone 12",
                            Price = 25000,
                            Discount = 0.15,
                            CategoryID = 1,
                            ImageURL = "https://productimages.hepsiburada.net/s/41/200-200/10698988879922.jpg"
                        },
                        new Product
                        {
                            Id = 2,
                            Name = "IPhone 13",
                            Price = 25000,
                            Discount = 0.15,
                            CategoryID = 1,
                            ImageURL = "https://productimages.hepsiburada.net/s/41/200-200/10698988879922.jpg"
                        },
                        new Product
                        {
                            Id = 3,
                            Name = "IPhone 14",
                            Price = 25000,
                            Discount = 0.15,
                            CategoryID = 1,
                            ImageURL = "https://productimages.hepsiburada.net/s/41/200-200/10698988879922.jpg"
                        },
                        new Product
                        {
                            Id = 4,
                            Name = "IPhone 16",
                            Price = 25000,
                            Discount = 0.15,
                            CategoryID = 1,
                            ImageURL = "https://productimages.hepsiburada.net/s/41/200-200/10698988879922.jpg"
                        },
                        new Product
                        {
                            Id = 5,
                            Name = "Lenovo Y700",
                            Price = 25000,
                            Discount = 0.15,
                            CategoryID = 2,
                            ImageURL = "https://productimages.hepsiburada.net/s/139/200-200/110000091548721.jpg"
                        },
                        new Product
                        {
                            Id = 6,
                            Name = "Asus Y720",
                            Price = 25000,
                            Discount = 0.15,
                            CategoryID = 2,
                            ImageURL = "https://productimages.hepsiburada.net/s/139/200-200/110000091548721.jpg"
                        },
                        new Product
                        {
                            Id = 7,
                            Name = "Dell Y750",
                            Price = 25000,
                            Discount = 0.15,
                            CategoryID = 2,
                            ImageURL = "https://productimages.hepsiburada.net/s/139/200-200/110000091548721.jpg"
                        },
                        new Product
                        {
                            Id = 8,
                            Name = "Sony Vaio",
                            Price = 25000,
                            Discount = 0.15,
                            CategoryID = 2,
                            ImageURL = "https://productimages.hepsiburada.net/s/139/200-200/110000091548721.jpg"
                        }
           );
        }
    }
}
