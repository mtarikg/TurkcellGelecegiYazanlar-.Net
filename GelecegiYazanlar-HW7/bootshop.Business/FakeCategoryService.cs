﻿using bootshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootshop.Business
{
    public class FakeCategoryService : ICategoryService
    {
        private List<Category> categories;

        public FakeCategoryService()
        {
            categories = new List<Category>()
            {
                new Category{ Id = 1, Name = "Computer" },
                new Category{ Id = 2, Name = "Phones" },
                new Category{ Id = 3, Name = "Tablet" },
            };
        }

        public IList<Category> GetCategories()
        {
            return categories;
        }
    }
}
