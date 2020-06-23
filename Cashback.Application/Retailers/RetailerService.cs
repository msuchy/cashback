using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Retailers;
using Cashback.Domain.Repositories;
using Cashback.Domain.Retailers;
using Cashback.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cashback.Application.Retailers
{
    public class RetailerService : IRetailerService
    {
        private readonly IRetailerRepository _retailerRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RetailerService(IRetailerRepository retailerRepository, IPasswordHasher passwordHasher)
        {
            _retailerRepository = retailerRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task Create(CreateRetailerDto retailerInfo)
        {
            var cpf = new Cpf(retailerInfo.CPF);
            var retailer = await _retailerRepository.Find(cpf);
            if (retailer != null)
                throw new ArgumentException("Retailer with the same CPF already created.");

            retailerInfo.Password = _passwordHasher.Hash(retailerInfo.Password);

            await _retailerRepository.Add(new Retailer(retailerInfo));
        }
    }
}