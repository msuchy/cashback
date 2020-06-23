using System;

namespace Cashback.Domain.Dtos.Orders
{
    public class OrderDetailsDto{
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CashbackPercent { get; set; }
        public decimal CashbackValue { get; set; }
    }
}