using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Retailers;
using Cashback.Domain.Repositories;
using Cashback.Domain.Retailers;
using Cashback.Repository.Context;
using Cashback.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Cashback.Repository.Repositories
{
    public class RetailerRepository : IRetailerRepository
    {
        private readonly CashbackContext _context;
        public RetailerRepository(CashbackContext context)
        {
            _context = context;
        }

        public async Task Add(Retailer retailer)
        {
            _context.Set<RetailerDbModel>()
                .Add(new RetailerDbModel()
                {
                    Id = Guid.NewGuid(),
                    CPF = retailer.CPF.Value,
                    Name = retailer.Name,
                    Password = retailer.Password,
                    Email = retailer.Email.Address,
                    PreApprovedOrders = retailer.PreApprovedOrders
                });
            await _context.SaveChangesAsync();
        }

        public async Task<Retailer> Find(Cpf cpf)
        {
            var dbModel = await _context.Set<RetailerDbModel>().FirstOrDefaultAsync(r => r.CPF == cpf.Value);
            if (dbModel == null)
                return null;

            return new Retailer(new CreateRetailerDto
            {
                CPF = dbModel.CPF,
                Name = dbModel.Name,
                Email = dbModel.Email,
                Password = dbModel.Password,
            }, dbModel.PreApprovedOrders);
        }
    }
}