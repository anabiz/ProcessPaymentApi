using System;
using System.Threading.Tasks;
using Internclap.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Data;
using PaymentApi.Dto;
using PaymentApi.Interfaces;
using PaymentApi.Models;

namespace PaymentApi.Services
{
    public class CheapPaymentGateway : BaseRepository<Payment>, ICheapPaymentGateway
    {
        private readonly PaymentContext _context;

        public CheapPaymentGateway(PaymentContext context): base(context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<PaymentDto>> ProcessCheapPayment(PaymentDto payment)
        {
            var response = new ServiceResponse<PaymentDto>();
            Payment newPayment = new Payment()
            {
                CreditCardNumber = payment.CreditCardNumber,
                CardHolder =payment.CardHolder,
                ExpirationDate = DateTime.Now,
                Amount = payment.Amount,
                SecurityCode = payment.SecurityCode

            };
            await Save(newPayment);

            //call external service here to process the payment
            //var result = await payStackService
            //_context.paymentStatuses.AddAsync(new PaymentStatus() {PaymentId=result.paymentId, status=result.status});

            response.Data = newPayment;
            return response;
        }
    }
}