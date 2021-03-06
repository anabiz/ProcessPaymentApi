using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Controllers;
using PaymentApi.Data;
using PaymentApi.Entities;
using PaymentApi.Interfaces;
using PaymentApiTest.ServicesTestImplementation;
using Xunit;

namespace PaymentApiTest
{
    public class PaymentControllerTest
    {
        PaymentController _paymentController;
        ICheapPaymentGateway _cheapRepository;
        IExpensivePaymentGateway _expensiveRepository;



        public PaymentControllerTest()
        {
            _cheapRepository = new CheapPaymentGateway1();
            _expensiveRepository = new ExpensivePaymentGateway1();

        }

        [Fact]
        public async void Task_ProcessPayment_Return_OkResult()
        {
            //Arrange  
            var controller = new PaymentController(_expensiveRepository,_cheapRepository);
            Payment newPayment = new Payment() { CreditCardNumber = "5399412014858888", CardHolder = "Android", ExpirationDate = DateTime.Now, SecurityCode = "000", Amount = 8 };

            //Act  
            var data = await controller.ProcessPayment(newPayment);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }


    }
}
