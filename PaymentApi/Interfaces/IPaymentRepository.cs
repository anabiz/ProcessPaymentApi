using System;
using System.Threading.Tasks;
using PaymentApi.Entities;

namespace PaymentApi.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPayment(int paymentId);

        Task Savepayment(Payment payment);

    }
}
