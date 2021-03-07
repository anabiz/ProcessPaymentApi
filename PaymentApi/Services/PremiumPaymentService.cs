using System;
using System.Threading.Tasks;
using Internclap.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using PaymentApi.Data;
using PaymentApi.Entities;
using PaymentApi.Interfaces;
using PaymentApi.Utils;
using Polly;

namespace PaymentApi.Services
{
    public class PremiumPaymentService : BaseRepository<Payment>,IPremiumPaymentService
    {
        private readonly IPaymentStatusRepository _statusRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly PaymentContext _context;
        private readonly ILogger<Payment> _logger;
        private readonly IPaypalService _paypalService;

        public PremiumPaymentService(IPaymentRepository paymentRepository,
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

        public async Task<ServiceResponse<Payment>> ProcessPremiumPayment(Payment payment)
        {

            var response = new ServiceResponse<Payment>();
            try
            {
                await _paymentRepository.Savepayment(payment);

                //call external service here to process the payment
                //await _paypalService.MakePayment();
                //var polly = Policy.Handle<Exception>()
                //    .WaitAndRetryAsync(3, sleep => TimeSpan.FromSeconds(3));
                //await polly.ExecuteAsync(async () =>
                //{
                //    _logger.LogInformation("Retrying ...");
                //    var result1 = await _paypalService.MakePayment();
                //});

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
