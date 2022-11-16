using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jac.Search.Models;

namespace Jac.Search.Interfaces
{
    public interface ISalesService
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}
