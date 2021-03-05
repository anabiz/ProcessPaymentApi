using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentApi.Models
{
    public class PaymentStatus
    {
        [ForeignKey("Payment")]
        [Key]
        public int PaymentId { get; set;}
        public string status { get; set; }
        public Payment payment {get; set;}
    }
}
