using System.Threading.Tasks;
using PaymentApi.Dto;
using PaymentApi.Entities;

namespace PaymentApi.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        Task<ServiceResponse<Payment>> ProcessExpensivePayment(PaymentDto payment);
    }
}