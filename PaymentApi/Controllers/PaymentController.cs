using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentApi.ControllersBase
{
    public class PaymentController : Controller
    {
        private readonly IExpensivePaymentGateway _expensivePayment;
        private readonly ICheapPaymentGateway _cheapPayment;

        public PaymentController(IExpensivePaymentGateway expensivePayment, ICheapPaymentGateway cheapPayment)
        {
            _expensivePayment = expensivePayment;
            _cheapPayment = cheapPayment;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
