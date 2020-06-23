using Cashback.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cashback.Repository.Context
{
    public class CashbackContext : DbContext
    {
        public CashbackContext(DbContextOptions<CashbackContext> options)
        : base(options)
        { }
        public DbSet<RetailerDbModel> Retailers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RetailerDbModel>().HasData(
                new RetailerDbModel
                {
                    Id = Guid.NewGuid(),
                    Email = "teste@teste.com",
                    Name = "Nome Completo",
                    CPF = "15350946056",
                    Password = "1000.QjdiW7smr68iulPruBLfjA==.8fe3CUazxsT4538/wPfS+s70yAOCsX94YcuFCqTLokg=",
                    PreApprovedOrders = true
                }
            );
        }
    }
}
