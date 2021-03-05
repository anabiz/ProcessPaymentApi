using System;
using PaymentApi.Dto;

namespace PaymentApi.Models
{
    public class Payment : PaymentDto
    {

        public int PaymentId { get; set;}
        
        //reference navigation property
        public PaymentStatus status { get; set; }
    }
}
