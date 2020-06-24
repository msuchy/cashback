using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Retailers;
using Cashback.Domain.Repositories;
using Cashback.Domain.Retailers;
using Cashback.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Cashback.Application.Retailers
{
    public class RetailerService : IRetailerService
    {
        private readonly IRetailerRepository _retailerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<RetailerService> _logger;

        public RetailerService(IRetailerRepository retailerRepository, IPasswordHasher passwordHasher, ILogger<RetailerService> logger)
        {
            _retailerRepository = retailerRepository;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }
        public async Task Create(CreateRetailerDto retailerInfo)
        {
            _logger.LogInformation($"CreateRetailerDto requested for {retailerInfo.CPF}");
            var cpf = new Cpf(retailerInfo.CPF);
            var retailer = await _retailerRepository.Find(cpf);
            if (retailer != null)
            {
                _logger.LogError($"Retailer with the same CPF already created. Cpf: {retailerInfo.CPF}");
                throw new ArgumentException("Retailer with the same CPF already created.");
            }

            retailerInfo.Password = _passwordHasher.Hash(retailerInfo.Password);

            await _retailerRepository.Add(new Retailer(retailerInfo));
        }
    }
}