﻿using System;
namespace PaymentApi.Entities
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
    }
    
}
