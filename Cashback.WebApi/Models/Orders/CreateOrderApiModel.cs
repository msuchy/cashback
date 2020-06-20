using System;

namespace Cashback.WebApi.Models.Orders
{
    public class CreateOrderApiModel{
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedOn { get; set; } 
        public string CPF { get; set; }
    }
}