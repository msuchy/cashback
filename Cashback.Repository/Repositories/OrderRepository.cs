using Cashback.Domain.Orders;
using Cashback.Domain.Repositories;
using Cashback.Repository.Context;
using Cashback.Repository.Models;
using Microsoft.EntityFrameworkCore;
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
                    ReferenceDate = order.ReferenceDate
                });
            await _context.SaveChangesAsync();
        }
    }
}