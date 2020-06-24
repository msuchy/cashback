using Cashback.Domain.Common;
using Cashback.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cashback.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task Add(Order order);

        Task<IEnumerable<Order>> FindOrdersByRetailerAndPeriod(Cpf cpf, DateTime initial, DateTime final);
    }
}