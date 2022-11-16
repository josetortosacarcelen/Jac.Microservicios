using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jac.Customers.Models;

namespace Jac.Customers.DAL
{
    public interface ICustomersProvider
    {
        Task<Customer> GetAsync(string id);
    }
}
