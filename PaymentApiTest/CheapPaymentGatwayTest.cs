using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Data;
using PaymentApi.Dto;
using PaymentApi.Entities;
using PaymentApi.Services;
using Xunit;

namespace PaymentApiTest
{
   
    public class CheapPaymentGatwayTest
    {
        private CheapPaymentGateway cheapRepository;

        public static DbContextOptions<PaymentContext> dbContextOptions { get; }
        public static string connectionString = "Data Source = PaymentTestDb.db";
        private readonly IMapper _mapper;
        public CheapPaymentGatwayTest(IMapper mapper)
        {
            _mapper = mapper;
         
        }


        [Fact]
        public void Task_ProcessCheapPayment_to_process_payment()
        {

            DbContextOptions dbContext = new DbContextOptionsBuilder<PaymentContext>()
             .UseSqlite(connectionString)
             .Options;


            var context = new PaymentContext(dbContextOptions);

            DummyTestDb db = new DummyTestDb();

            db.Seed(context);
            //Arrange  
            CheapPaymentGateway repository = new CheapPaymentGateway(context, _mapper);


            PaymentDto newPayment = new PaymentDto() { CreditCardNumber = "5399412014853535", CardHolder = "java", ExpirationDate = DateTime.Now, SecurityCode = "904", Amount = 8 };
            //Act
            var result = repository.ProcessCheapPayment(newPayment);

            //Assert  
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
