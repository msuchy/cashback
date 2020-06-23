using Cashback.Domain.Retailers;
using System;

namespace Cashback.Domain.Orders
{
    public class Order
    {
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime ReferenceDate { get; set; }
        public Retailer Retailer { get; set; }
        public OrderStatus Status { get; set; }

        public Order(string code, decimal value, DateTime referenceDate, Retailer retailer)
        {
            Code = code;
            Value = value;
            ReferenceDate = referenceDate;
            Retailer = retailer;
            Status = retailer.PreApprovedOrders ? OrderStatus.Approved : OrderStatus.Validating;
        }
    }
}
