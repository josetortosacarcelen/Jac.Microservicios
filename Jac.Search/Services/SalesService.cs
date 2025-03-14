﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jac.Search.Interfaces;
using Jac.Search.Models;
using Newtonsoft.Json;

namespace Jac.Search.Services
{
    public class SalesService : ISalesService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public SalesService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var client = httpClientFactory.CreateClient("salesService");

            var response = await client.GetAsync($"api/sales/{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var orders = JsonConvert.DeserializeObject<ICollection<Order>>(content);

                return orders;
            }

            return null;

        }
    }
}
