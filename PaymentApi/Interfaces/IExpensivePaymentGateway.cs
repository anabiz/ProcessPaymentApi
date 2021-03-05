using System.Threading.Tasks;
using PaymentApi.Dto;
using PaymentApi.Models;

namespace PaymentApi.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        Task<ServiceResponse<PaymentDto>> ProcessExpensivePayment(PaymentDto payment);
    }
}