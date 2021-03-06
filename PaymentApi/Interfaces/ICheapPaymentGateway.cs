using System.Threading.Tasks;
using PaymentApi.Dto;
using PaymentApi.Entities;

namespace PaymentApi.Interfaces
{
    public interface ICheapPaymentGateway
    {
        Task<ServiceResponse<Payment>> ProcessCheapPayment(PaymentDto payment);
    }
}