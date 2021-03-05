using PaymentApi.Dto;

namespace PaymentApi.Interfaces
{
    public interface ICheapPaymentGateway
    {
        string ProcessCheapPayment(PaymentDto payment);
    }
}