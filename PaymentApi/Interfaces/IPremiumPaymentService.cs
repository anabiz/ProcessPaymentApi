using System;
using System.Threading.Tasks;
using PaymentApi.Entities;

namespace PaymentApi.Interfaces
{
    public interface IPremiumPaymentService
    {
        Task<ServiceResponse<Payment>> ProcessPremiumPayment(Payment payment);
    }
}
