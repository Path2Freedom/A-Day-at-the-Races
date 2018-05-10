using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace A_Day_at_the_Races
{
    public class Guy
    {
        //Fields
        public string Name;
        public int Cash;
        public Bet MyBet;

        public RadioButton MyRadioButton;
        public TextBlock MyLabel; 
        
        //Methods
        public void UpdateLabels()
        {
            MyRadioButton.Content = Name + " has " + Cash + " bucks";
            MyLabel.Text = MyBet.GetDescription();
        } 
                
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (BetAmount <= Cash)
            {
                Cash -= BetAmount;
                MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };
                UpdateLabels();
                return true;
            }
            else
                return false;
        }

        public void ClearBet()
        {
            PlaceBet(0, 0);
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            UpdateLabels();                        
        }
    }
}
