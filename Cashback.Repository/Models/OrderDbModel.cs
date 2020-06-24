using Cashback.Domain.Orders;
using System;

namespace Cashback.Repository.Models
{
    public class OrderDbModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid RetailerId { get; set; }
        public RetailerDbModel Retailer { get; set; }
        public decimal Value { get; set; }
        public DateTime ReferenceDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}