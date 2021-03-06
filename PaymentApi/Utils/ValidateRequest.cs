using System;
using PaymentApi.Dto;

namespace PaymentApi.Utils
{
    public class ValidateRequest
    {
        public static bool validateRequest(PaymentDto request)
        {
            var daysDifference = getDaysDiff(DateTime.Now, request.ExpirationDate);

            if (request.Amount <= 0)
            {
                return false;
            }else if(daysDifference <= 0)
            {
                return false;
            }

            return true;
        }


        private static long getDaysDiff(DateTime fisrtDate, DateTime secondDate)
        {
            return (secondDate - fisrtDate).Days;
        }
    }
}
