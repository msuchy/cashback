using System;

namespace Cashback.Repository.Models
{
    public class RetailerDbModel
    {
        public Guid Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool PreApprovedOrders { get; set; }
    }
}