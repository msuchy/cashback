using System;

namespace Cashback.Domain.Dtos.Orders
{
    public class CreateOrderDto{
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedOn { get; set; } 
    }
}