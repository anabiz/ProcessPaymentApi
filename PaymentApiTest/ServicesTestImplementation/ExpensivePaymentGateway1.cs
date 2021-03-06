using System;
using System.Threading.Tasks;
using AutoMapper;
using PaymentApi.Dto;
using PaymentApi.Entities;
using PaymentApi.Interfaces;

namespace PaymentApiTest.ServicesTestImplementation
{
    public class ExpensivePaymentGateway1 : IExpensivePaymentGateway
    {
        //private readonly IMapper _mapper;

        public ExpensivePaymentGateway1()
        {
            
        }

        public async Task<ServiceResponse<Payment>> ProcessExpensivePayment(PaymentDto payment)
        {
            var response = new ServiceResponse<Payment>();

            Payment newPayment = new Payment()
            {

            };

            response.Data = newPayment;

            return response;
        }
    }
}