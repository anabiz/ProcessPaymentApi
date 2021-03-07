using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PaymentApi.Utils
{
    public class CheckValidCard
    {

        public static bool CheckCard(string cardNo)
        {
            
                // check whether input string is null or empty
                if (string.IsNullOrEmpty(cardNo))
                {
                    return false;
                }

                int sumOfDigits = cardNo.Where((e) => e >= '0' && e <= '9')
                                .Reverse()
                                .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                                .Sum((e) => e / 10 + e % 10);


                return sumOfDigits % 10 == 0;
            }
        }
}
