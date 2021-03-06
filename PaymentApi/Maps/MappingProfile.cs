using System;
using AutoMapper;
using PaymentApi.Dto;
using PaymentApi.Entities;

namespace PaymentApi.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentDto, Payment>();
        }
    }
}
