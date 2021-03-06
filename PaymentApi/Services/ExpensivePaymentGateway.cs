using System;
using System.Threading.Tasks;
using Internclap.Infrastructure.Services;
using PaymentApi.Data;
using PaymentApi.Dto;
using PaymentApi.Interfaces;
using PaymentApi.Entities;
using AutoMapper;

namespace PaymentApi.Services
{
    public class ExpensivePaymentGateway : BaseRepository<Payment>, IExpensivePaymentGateway
    {
        private readonly PaymentContext _context;
        private readonly IMapper _mapper;

        public ExpensivePaymentGateway(PaymentContext context, IMapper mapper) : base(context)
        {
            
              _mapper = mapper;
        }

        public async Task<ServiceResponse<Payment>> ProcessExpensivePayment(PaymentDto payment)
        {
            var response = new ServiceResponse<Payment>();

            Payment newPayment = _mapper.Map<Payment>(payment);
            await Save(newPayment);

            //call external service here to process the payment
            //var result = await payStackService
            //_context.paymentStatuses.AddAsync(new PaymentStatus() {PaymentId=result.paymentId, status=result.status});

            response.Data = newPayment;
            return response;
        }
    }
}