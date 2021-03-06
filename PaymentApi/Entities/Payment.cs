using System;
using PaymentApi.Dto;

namespace PaymentApi.Entities
{
    public class Payment : PaymentDto
    {

        public int PaymentId { get; set;}
        
        //reference navigation property
        public PaymentStatus PaymentState { get; set; }
    }
}
