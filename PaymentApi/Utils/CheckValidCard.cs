using System;
namespace PaymentApi.Utils
{
    public class CheckValidCard
    {
  
        public static bool CheckCard(string card)
        {
            if (card.Length < 12 || card.Length > 19)
            {
                return false;
            }

            return true;
        }
    }
}
