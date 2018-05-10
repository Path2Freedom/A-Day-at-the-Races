using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Day_at_the_Races
{
    public class Bet
    {
        //Fields
        public int Amount;
        public int Dog;
        public Guy Bettor;

        //Methods
        public string GetDescription()
        {
            if (Amount > 0)
                return Bettor.Name + " bets " + Amount + " on dog #" + Dog;
            else
                return Bettor.Name + " hasn't placed a bet";                     
        }

        public int PayOut(int Winner)
        {
            if (Winner == Dog)
                return Amount;
            else
                return -Amount;
        }
    }
}
