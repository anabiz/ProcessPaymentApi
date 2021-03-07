using System;
using System.Threading.Tasks;
using Internclap.Infrastructure.Services;
using PaymentApi.Data;
using PaymentApi.Entities;
using PaymentApi.Interfaces;

namespace PaymentApi.Services
{
    public class PaymentStatusRepository: BaseRepository<PaymentStatus>, IPaymentStatusRepository
    {
        private readonly PaymentContext _context;

        public PaymentStatusRepository( PaymentContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaymentStatus> SavePaymentStatus(PaymentStatus paymentstatus)
        {
            await _context.paymentStatuses.AddAsync(paymentstatus);
            await _context.SaveChangesAsync();
            return paymentstatus;
        }
    }
}
