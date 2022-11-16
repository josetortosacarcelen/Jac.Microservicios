using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jac.Sales.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Jac.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesProvider salesProvider;
        public SalesController(ISalesProvider salesProvider)
        {
            this.salesProvider = salesProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var orders = await salesProvider.GetAsync(customerId);

            if (orders != null && orders.Any())
            {
                return Ok(orders);
            }

            return NotFound();
        }
    }
}
