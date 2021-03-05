using System;
namespace PaymentApi.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
    }
    
}
