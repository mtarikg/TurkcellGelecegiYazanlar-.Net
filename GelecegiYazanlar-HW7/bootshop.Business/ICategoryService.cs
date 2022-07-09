using bootshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootshop.Business
{
    public interface ICategoryService
    {
        IList<Category> GetCategories();
    }
}
