using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Dto
{
    public class PaymentDto
    {
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public int Amount { get; set; }
        [MaxLength(3)]
        [MinLength(3)]
        public string SecurityCode { get; set; }
    
    }
}
