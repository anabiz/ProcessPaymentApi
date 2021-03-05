using System;
using PaymentApi.Models;
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
