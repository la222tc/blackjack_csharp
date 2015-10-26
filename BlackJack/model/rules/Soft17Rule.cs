using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17Rule : IHitStrategy
    {
        /* 
    *  Soft 17 means that the dealer has 17 but in a combination of Ace and 6 (for example Ess, tvåa, tvåa, tvåa).
    *  This means that the Dealern can get another card valued at 10 but still have 17 as the value of the ace is reduced to 1.
    *  Using the soft 17 rule the dealer should take another card
    *  (compared to the original rule when the dealer only takes cards on a score of 16 or lower).
    */
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {

            int score = a_dealer.CalcScore();

            if (score < g_hitLimit)
            {
                return true;
            }

            if (score == g_hitLimit)
            {
                foreach (Card c in a_dealer.GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace)
                    {
                        score -= 10;
                    }
                }

                return score < g_hitLimit;
            }

            return false;
        }
    }
}
