using System;
using PaymentApi.Data;
using PaymentApi.Entities;

namespace PaymentApiTest
{
    public class DummyTestDb
    {
        public DummyTestDb()
        {
        }

        public void Seed(PaymentContext context)  
        {  
            context.Database.EnsureDeleted();  
            context.Database.EnsureCreated();  
  
            //context.Payments.AddRange(  
            //    new Payment() { CreditCardNumber = "5399412014859090", CardHolder = "csharp", ExpirationDate= DateTime.Now, SecurityCode="789", Amount= 19 },  
            //    new Payment() { CreditCardNumber = "5399412014852222", CardHolder = "javascript", ExpirationDate= DateTime.Now, SecurityCode="129", Amount= 78 },
            //    new Payment() { CreditCardNumber = "5399412014853535", CardHolder = "java", ExpirationDate= DateTime.Now, SecurityCode="904", Amount= 8 } 
      
            //);  
              
            //context.paymentStatuses.AddRange(  
            //    new PaymentStatus() { PaymentId = 1, status = "processed" },  
            //    new PaymentStatus() { PaymentId = 2, status = "pending" }, 
            //    new PaymentStatus() { PaymentId = 3, status = "faild" }
            //);  
            //context.SaveChanges();  
        } 
    }
}
