using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jac.Sales.Models;

namespace Jac.Sales.DAL
{
    public interface ISalesProvider
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}
