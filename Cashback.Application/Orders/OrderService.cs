using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Orders;
using Cashback.Domain.Orders;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Cashback.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IRetailerRepository _retailerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICashbackService _cashbackService;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IRetailerRepository retailerRepository, IOrderRepository orderRepository, ICashbackService cashbackService, ILogger<OrderService> logger)
        {
            _retailerRepository = retailerRepository;
            _orderRepository = orderRepository;
            _cashbackService = cashbackService;
            _logger = logger;
        }

        public async Task Create(CreateOrderDto orderInfo, string retailerCpf)
        {
            var cpf = new Cpf(retailerCpf);
            var retailer = await _retailerRepository.Find(cpf);
            if (retailer == null)
                throw new ArgumentException("Retailer not found");

            var order = new Order(orderInfo.Code, orderInfo.Value, orderInfo.ReferenceDate, retailer);
            await _orderRepository.Add(order);
            _logger.LogInformation("Order created");
        }

        public async Task<IEnumerable<OrderDetailsDto>> ListCurrentMonth(string retailerCpf)
        {
            var cpf = new Cpf(retailerCpf);
            var retailer = await _retailerRepository.Find(cpf);
            if (retailer == null)
                throw new ArgumentException("Retailer not found");

            var currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            var orders = await _orderRepository.FindOrdersByRetailerAndPeriod(cpf, currentMonth, DateTime.Now);

            var currentTotalAmount = orders.Sum(o => o.Value);
            var currentCashbackPercent = _cashbackService.GetPercentByTotalAmount(currentTotalAmount);
            var intCashback = (int)(currentCashbackPercent * 100);

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
