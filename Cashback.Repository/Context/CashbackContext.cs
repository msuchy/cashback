using System;
using Cashback.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Cashback.Repository.Context
{
    public class CashbackContext : DbContext
    {
        public CashbackContext(DbContextOptions<CashbackContext> options)
        : base(options)
        { }
        public DbSet<RetailerDbModel> Retailers { get; set; }
    }
}
