using PaymentApi.Dto;

namespace PaymentApi.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        string ProcessCheapPayment(PaymentDto payment);
    }
}