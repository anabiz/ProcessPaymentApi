using System;
using System.Net.Http;
using System.Threading.Tasks;
using PaymentApi.Interfaces;
using PaymentApi.Entities;
using System.Collections.Generic;

namespace PaymentApi.Services
{
    public class PaypalService : IPaypalService
    {
        private static IHttpClientFactory _httpClientFactory;

        public PaypalService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task<string> MakePayment(Payment payment)
        {
           var values = new Dictionary<string, string>
           {
               { "card_number", $"{payment.CreditCardNumber}" },
               { "currency", "EUR" },
               { "amount", $"{payment.Amount}" },
               { "cvv", "" },
               {"pin", ""},
               {"email", ""}
               { "expiry_month", $"{payment.ExpirationDate.Month}" },
               { "expiry_year", $"{payment.ExpirationDate.Year}" }

            };

            var content = new FormUrlEncodedContent(values);

            //var httpClient = new HttpClient();
            var httpClient1 = _httpClientFactory.CreateClient("paypal");
            var response = await httpClient1.PostAsync("url",content);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
