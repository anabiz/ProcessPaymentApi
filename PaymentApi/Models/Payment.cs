using System;

namespace PaymentApi.Models
{
    public class Payment
    {

        public int PaymentId { get; set;}
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public int Amount { get; set; }
        //reference navigation property
        public PaymentStatus status { get; set; }
    }
}
