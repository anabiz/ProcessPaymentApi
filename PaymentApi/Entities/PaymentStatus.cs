using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentApi.Entities
{
    public class PaymentStatus
    {
        [ForeignKey("Payment")]
        [Key]
        public int PaymentId { get; set;}
        public string status { get; set; }
    }
}
