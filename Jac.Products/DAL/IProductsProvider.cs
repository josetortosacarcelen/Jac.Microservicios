using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jac.Products.Models;

namespace Jac.Products.DAL
{
    public interface IProductsProvider
    {
        Task<Product> GetAsync(string id);
    }
}
