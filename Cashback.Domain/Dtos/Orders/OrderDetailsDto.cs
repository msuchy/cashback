using Cashback.Domain.Orders;
using System;

namespace Cashback.Domain.Dtos.Orders
{
    public class OrderDetailsDto{
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime ReferenceDate { get; set; }
        public int CashbackPercent { get; set; }
        public decimal CashbackValue { get; set; }
        public OrderStatus Status { get; set; }
    }
}