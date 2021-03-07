using System;
using System.Threading.Tasks;

namespace PaymentApi.Utils
{
    public class MakePayment
    {

        public static async Task<string> InitiatePayment()
        {
            Random _random = new Random();
            var num = _random.Next(1, 3);
            if (num <= 1) return "processed";
            if (num <= 2 && num > 1) return "failed";
            return "pending";
        }
    }
}
