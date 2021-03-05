using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Dto;
using PaymentApi.Interfaces;
using PaymentApi.Utils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentApi.Controllers
{

    [Route("apiv1/processpayment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IExpensivePaymentGateway _expensivePayment;
        private readonly ICheapPaymentGateway _cheapPayment;

        public PaymentController(IExpensivePaymentGateway expensivePayment, ICheapPaymentGateway cheapPayment)
        {
            _expensivePayment = expensivePayment;
            _cheapPayment = cheapPayment;
        }


        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentDto payment)
        {
            if(!CheckValidCard.CheckCard(payment.CreditCardNumber)) return BadRequest();
            try
            {
                if(payment.Amount <= 20)
                {
                    return Ok(await _cheapPayment.ProcessCheapPayment(payment));

                }else if (payment.Amount > 20 && payment.Amount <= 500)
                {
                    return Ok(await _expensivePayment.ProcessExpensivePayment(payment));
                }

                return Ok();
            }
            catch (Exception e)
            {
  
                return StatusCode(500);
            }
            
        }
    }
}
