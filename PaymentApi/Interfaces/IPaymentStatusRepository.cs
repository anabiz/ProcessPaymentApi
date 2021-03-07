using System;
using System.Threading.Tasks;
using PaymentApi.Entities;

namespace PaymentApi.Interfaces
{
    public interface IPaymentStatusRepository
    {
        Task<PaymentStatus> SavePaymentStatus(PaymentStatus paymentstatus);

    }
}
