﻿using System.Threading.Tasks;
using Jac.Products.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Jac.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            this.productsProvider = productsProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var product = await productsProvider.GetAsync(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }
    }
}
