using System;
using System.Threading.Tasks;
using Internclap.Infrastructure.Services;
using PaymentApi.Data;
using PaymentApi.Interfaces;
using PaymentApi.Entities;
using PaymentApi.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace PaymentApi.Services
{
    public class ExpensivePaymentGateway : BaseRepository<Payment>, IExpensivePaymentGateway
    {
        private readonly IPaymentStatusRepository _statusRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly PaymentContext _context;
        private readonly ILogger<Payment> _logger;
        private readonly IPaypalService _paypalService;

        public ExpensivePaymentGateway(IPaymentRepository paymentRepository,
                                       IPaymentStatusRepository statusRepository,
                                       PaymentContext context,
                                       ILogger<Payment> logger,
                                       IPaypalService paypalService) : base(context)
        {
            _statusRepository = statusRepository;
            _paymentRepository = paymentRepository;
            _logger = logger;
            _paypalService = paypalService;

        }

        public async Task<ServiceResponse<Payment>> ProcessExpensivePayment(Payment payment)
        {
            var response = new ServiceResponse<Payment>();
            try
            {
                await _paymentRepository.Savepayment(payment);

                //call external service here to process the payment
                //await _paypalService.MakePayment();

                var result = await MakePayment.InitiatePayment();

                PaymentStatus status = new PaymentStatus() { PaymentId = payment.PaymentId, status = result };
                await _statusRepository.SavePaymentStatus(status);

                response.Data = await _paymentRepository.GetPayment(status.PaymentId);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return null;
        }
    }
}