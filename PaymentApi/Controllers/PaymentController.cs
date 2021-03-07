using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Dto;
using PaymentApi.Entities;
using PaymentApi.Interfaces;
using PaymentApi.Utils;


namespace PaymentApi.Controllers
{

    [Route("apiv1/processpayment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IExpensivePaymentGateway _expensivePayment;
        private readonly ICheapPaymentGateway _cheapPayment;
        private readonly IPremiumPaymentService _premiumPayment;
        private readonly IMapper _mapper;

        public PaymentController(IExpensivePaymentGateway expensivePayment, ICheapPaymentGateway cheapPayment, IMapper mapper, IPremiumPaymentService premiumPayment)
        {
            _expensivePayment = expensivePayment;
            _cheapPayment = cheapPayment;
            _premiumPayment = premiumPayment;
            _mapper = mapper;

        }


        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentDto payment)
        {
            if(!CheckValidCard.CheckCard(payment.CreditCardNumber)) return BadRequest("invalid CCN");
            if (!ValidateRequest.validateRequest(payment)) return BadRequest("invalid request");

            try
            {
                Payment newPayment = _mapper.Map<Payment>(payment);
                if (payment.Amount <= 20)
                {
                    return Ok(await _cheapPayment.ProcessCheapPayment(newPayment));

                }
                else if (payment.Amount > 20 && payment.Amount <= 500)
                {
                    return Ok(await _expensivePayment.ProcessExpensivePayment(newPayment));
                }else
                {
                    return Ok(await _premiumPayment.ProcessPremiumPayment(newPayment));
                }
                
                
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            
        }
    }
}
