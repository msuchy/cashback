using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Orders;
using Cashback.Domain.Orders;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IRetailerRepository _retailerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICashbackService _cashbackService;

        public OrderService(IRetailerRepository retailerRepository, IOrderRepository orderRepository, ICashbackService cashbackService)
        {
            _retailerRepository = retailerRepository;
            _orderRepository = orderRepository;
            _cashbackService = cashbackService;
        }

        public async Task Create(CreateOrderDto orderInfo, string retailerCpf)
        {
            var cpf = new Cpf(retailerCpf);
            var retailer = await _retailerRepository.Find(cpf);
            if (retailer == null)
                throw new ArgumentException("Retailer not found");

            var order = new Order(orderInfo.Code, orderInfo.Value, orderInfo.ReferenceDate, retailer);
            await _orderRepository.Add(order);
        }

        public async Task<IEnumerable<OrderDetailsDto>> List(string retailerCpf)
        {
            var cpf = new Cpf(retailerCpf);
            var retailer = await _retailerRepository.Find(cpf);
            if (retailer == null)
                throw new ArgumentException("Retailer not found");

            var orders = await _orderRepository.FindCurrentMonthByRetailer(cpf);

            var currentTotalAmount = orders.Sum(o => o.Value);
            var currentCashbackPercent = _cashbackService.GetPercentByTotalAmount(currentTotalAmount);
            var intCashback = (int)currentCashbackPercent * 100;

            return orders.Select(o => new OrderDetailsDto()
            {
                Code = o.Code,
                ReferenceDate = o.ReferenceDate,
                Value = o.Value,
                CashbackPercent = intCashback,
                CashbackValue = o.Value * currentCashbackPercent,
                Status = o.Status
            });

        }
    }
}
