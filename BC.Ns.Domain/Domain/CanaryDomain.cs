﻿using BC.Ns.Domain.Interface;
using System.Threading.Tasks;
using BC.WebApi.Logger;
using System.Security.Principal;
using System.Net.Http;

namespace BC.Ns.Domain.Domain
{
    public class CanaryDomain : ICanaryDomain
    {
        private ILogger<CanaryDomain> _logger;

        public CanaryDomain(ILogger<CanaryDomain> logger)
        {
            _logger = logger;
        }

        public async Task<bool> GetTest()
        {
            var a = new Product();
            if (a.P.P == null)
            { }

            return await Task.FromResult<bool>(true);
        }
    }

    public class Product
    {
        public Product P { get; set; }
    }
}
