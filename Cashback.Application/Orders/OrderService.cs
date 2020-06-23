using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Orders;
using Cashback.Domain.Orders;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;
using System;
using System.Threading.Tasks;

namespace Cashback.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IRetailerRepository _retailerRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IRetailerRepository retailerRepository, IOrderRepository orderRepository)
        {
            _retailerRepository = retailerRepository;
            _orderRepository = orderRepository;
        }

        public async Task Create(CreateOrderDto orderInfo, string retailerCpf)
        {
            var cpf = new Cpf(retailerCpf);
            var retailer = await _retailerRepository.Find(cpf);
            if (retailer == null)
                throw new ArgumentException("Retailer not found");

            var order = new Order(orderInfo.Code, orderInfo.Value, orderInfo.CreatedOn, retailer);
            await _orderRepository.Add(order);
        }
    }
}
