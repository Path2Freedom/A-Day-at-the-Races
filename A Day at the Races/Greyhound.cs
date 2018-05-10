using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace A_Day_at_the_Races
{
    public class Greyhound
    {
        //Fields
        public Image MyPictureBox = null; 
        public int RaceTrackLength;
        public int RandomDisplacement;
        public int DistanceCovered; 
        public Random Randomizer; 
        public TranslateTransform TT = new TranslateTransform();        

        //Methods
        public bool Run()
        {
            RandomDisplacement = Randomizer.Next(8);
            DistanceCovered += RandomDisplacement;
            TT.X = DistanceCovered;            
            MyPictureBox.RenderTransform = TT;

            if (DistanceCovered >= RaceTrackLength)
                return true;
            else
                return false;            
        }

        public void TakeStartingPosition()
        {
            TT.X = 5;
            MyPictureBox.RenderTransform = TT;
            DistanceCovered = 0;         
        }
    }
}
