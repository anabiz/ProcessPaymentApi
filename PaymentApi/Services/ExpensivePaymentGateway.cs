using PaymentApi.Data;
using PaymentApi.Dto;
using PaymentApi.Interfaces;

namespace PaymentApi.Services
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private PaymentContext _context;

        public ExpensivePaymentGateway(PaymentContext context)
        {
            _context = context;
        }

        public string ProcessCheapPayment(PaymentDto payment)
        {
            
            throw new System.NotImplementedException();
        }
    }
}