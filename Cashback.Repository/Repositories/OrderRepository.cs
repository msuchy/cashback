using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Retailers;
using Cashback.Domain.Orders;
using Cashback.Domain.Repositories;
using Cashback.Domain.Retailers;
using Cashback.Repository.Context;
using Cashback.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CashbackContext _context;
        public OrderRepository(CashbackContext context)
        {
            _context = context;
        }

        public async Task Add(Order order)
        {
            var retailer = await _context.Set<RetailerDbModel>().FirstOrDefaultAsync(r => r.CPF == order.Retailer.CPF.Value);
            _context.Set<OrderDbModel>()
                .Add(new OrderDbModel()
                {
                    Code = order.Code,
                    RetailerId = retailer.Id,
                    Value = order.Value,
                    ReferenceDate = order.ReferenceDate,
                    Status = order.Status
                });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> FindCurrentMonthByRetailer(Cpf cpf)
        {
            var currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 0);
            return await _context.Set<OrderDbModel>().Where(r => r.Retailer.CPF == cpf.Value && r.ReferenceDate >= currentMonth)
                .Select(o => new Order(
                
                    o.Code,
                    o.Value,
                    o.ReferenceDate,
                    new Retailer(new CreateRetailerDto
                    {
                        CPF = o.Retailer.CPF,
                        Name = o.Retailer.Name,
                        Email = o.Retailer.Email,
                        Password = o.Retailer.Password,
                    }, o.Retailer.PreApprovedOrders),
                    o.Status
                ))
                .ToListAsync();
        }
    }
}