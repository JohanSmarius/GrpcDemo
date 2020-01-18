﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class ShopService : Protos.ShopService.ShopServiceBase
    {
        private readonly ILogger<ShopService> _logger;

        public ShopService(ILogger<ShopService> logger)
        {
            _logger = logger;
        }
        public override Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received customer", null);

            var response = new CreateCustomerResponse
            {
                Id = new Random().Next(1000),
                Name = request.Name
            };

            return Task.FromResult(response);
        }
    }
}