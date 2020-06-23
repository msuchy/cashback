using System;

namespace Cashback.Domain.Dtos.Orders
{
    public class CreateOrderDto{
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedOn { get; set; } 
        public string CPF { get; set; }
    }
}