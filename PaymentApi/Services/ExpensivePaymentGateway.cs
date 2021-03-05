using System;
using System.Threading.Tasks;
using Internclap.Infrastructure.Services;
using PaymentApi.Data;
using PaymentApi.Dto;
using PaymentApi.Interfaces;
using PaymentApi.Models;

namespace PaymentApi.Services
{
    public class ExpensivePaymentGateway : BaseRepository<Payment>, IExpensivePaymentGateway
    {
        
        public ExpensivePaymentGateway(PaymentContext context): base(context)
        {
            
        }

        public async Task<ServiceResponse<PaymentDto>> ProcessExpensivePayment(PaymentDto payment)
        {
            var response = new ServiceResponse<PaymentDto>();

            Payment newPayment = new Payment()
            {
                CreditCardNumber = payment.CreditCardNumber,
                CardHolder = payment.CardHolder,
                ExpirationDate = DateTime.Now,
                Amount = payment.Amount,
                SecurityCode = payment.SecurityCode
            };
            await Save(newPayment);

            //call external service here to process the payment
            //var result = await payStackService
            //_context.paymentStatuses.AddAsync(new PaymentStatus() {PaymentId=result.paymentId, status=result.status});

            response.Data = payment;
            return response;
        }
    }
}