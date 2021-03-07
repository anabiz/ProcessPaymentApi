using System;
using System.Threading.Tasks;
using PaymentApi.Entities;

namespace PaymentApi.Interfaces
{
    public interface IPaypalService
    {
        
        Task<string> MakePayment(Payment payment);
        
    }
}
