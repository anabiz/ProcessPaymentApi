using System;
using System.Linq;
using System.Threading.Tasks;
using Internclap.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Data;
using PaymentApi.Entities;
using PaymentApi.Interfaces;

namespace PaymentApi.Services
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly PaymentContext _context;

        public PaymentRepository(PaymentContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Payment> GetPayment(int paymentId)
        {
            return await _context.Payments
                    .Include(status => status.PaymentState)
                    .Where(c => c.PaymentId == paymentId)
                    .FirstOrDefaultAsync();

        }

        public async Task Savepayment(Payment payment)
        {
            await Save(payment);
        }
    }
}
