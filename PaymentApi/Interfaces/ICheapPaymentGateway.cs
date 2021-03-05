using System.Threading.Tasks;
using PaymentApi.Dto;
using PaymentApi.Models;

namespace PaymentApi.Interfaces
{
    public interface ICheapPaymentGateway
    {
        Task<ServiceResponse<PaymentDto>> ProcessCheapPayment(PaymentDto payment);
    }
}