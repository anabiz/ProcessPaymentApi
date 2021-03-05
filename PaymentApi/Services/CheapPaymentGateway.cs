using PaymentApi.Dto;
using PaymentApi.Interfaces;

namespace PaymentApi.Services
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public string ProcessCheapPayment(PaymentDto payment)
        {
            throw new System.NotImplementedException();
        }
    }
}