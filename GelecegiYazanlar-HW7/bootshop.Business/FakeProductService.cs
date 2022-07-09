using bootshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootshop.Business
{
    public class FakeProductService : IProductService
    {
        private List<Product> products;

        public FakeProductService()
        {
            products = new List<Product>
            {
                new Product{Id =1, Name = "Dell XPS 13", Price = 10000, Discount = 0.15, Description = "8 GB ram", CategoryID = 1,
                    ImageURL = "https://productimages.hepsiburada.net/s/94/200-200/110000036607843.jpg" },
                new Product{Id =2, Name = "Samsung XPS 13", Price = 10000, Discount = 0.15, Description = "8 GB ram", CategoryID = 1,
                    ImageURL = "https://productimages.hepsiburada.net/s/94/200-200/110000036607843.jpg" },
                new Product{Id =3, Name = "Lenovo XPS 13", Price = 10000, Discount = 0.15, Description = "8 GB ram", CategoryID = 2,
                    ImageURL = "https://productimages.hepsiburada.net/s/94/200-200/110000036607843.jpg" },
                new Product{Id =4, Name = "Sony XPS 13", Price = 10000, Discount = 0.15, Description = "8 GB ram", CategoryID = 3,
                    ImageURL = "https://productimages.hepsiburada.net/s/94/200-200/110000036607843.jpg" },
                new Product{Id =5, Name = "Dell XPS 13", Price = 10000, Discount = 0.15, Description = "8 GB ram", CategoryID = 2,
                    ImageURL = "https://productimages.hepsiburada.net/s/94/200-200/110000036607843.jpg" },
                new Product{Id =6, Name = "Samsung XPS 13", Price = 10000, Discount = 0.15, Description = "8 GB ram", CategoryID = 3,
                    ImageURL = "https://productimages.hepsiburada.net/s/94/200-200/110000036607843.jpg" },
                new Product{Id =7, Name = "Lenovo XPS 13", Price = 10000, Discount = 0.15, Description = "8 GB ram", CategoryID = 1,
                    ImageURL = "https://productimages.hepsiburada.net/s/94/200-200/110000036607843.jpg" },
                new Product{Id =8, Name = "Sony XPS 13", Price = 10000, Discount = 0.15, Description = "8 GB ram",CategoryID = 1,
                    ImageURL = "https://productimages.hepsiburada.net/s/94/200-200/110000036607843.jpg" }
            };
        }

        public Task<int> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProducts()
        {
            return products;
        }

        Task<ICollection<Product>> IProductService.GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
