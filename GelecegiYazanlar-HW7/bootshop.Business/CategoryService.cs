using bootshop.DataAccess.Data;
using bootshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootshop.Business
{
    public class CategoryService : ICategoryService
    {
        private bootshopDbContext dbContext;

        public CategoryService(bootshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }
    }
}
