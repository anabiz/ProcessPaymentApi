using System;
using PaymentApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace PaymentApi.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {

        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> paymentStatuses { get; set; }

      
    }
}
