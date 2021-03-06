using System;
using System.Threading.Tasks;
using AutoMapper;
using PaymentApi.Dto;
using PaymentApi.Entities;
using PaymentApi.Interfaces;

namespace PaymentApiTest.ServicesTestImplementation
{
    public class CheapPaymentGateway1 : ICheapPaymentGateway
    {
        

        public CheapPaymentGateway1()
        {
            
        }

        public async Task<ServiceResponse<Payment>> ProcessCheapPayment(PaymentDto payment)
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
