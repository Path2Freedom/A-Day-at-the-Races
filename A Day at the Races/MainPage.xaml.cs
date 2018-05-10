using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace A_Day_at_the_Races
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Fields
        Greyhound[] greyhound = new Greyhound[4];
        Guy[] guy = new Guy[3];
        Random MyRandomizer = new Random();
        Stopwatch timer;
        int winnerDog;

        public MainPage()
        {
            this.InitializeComponent();

            timer = new Stopwatch();

            winnerDog = 0;

            greyhound[0] = new Greyhound()
            {
                MyPictureBox = Dog1,
                RaceTrackLength = 530,
                Randomizer = MyRandomizer
            };

            greyhound[1] = new Greyhound()
            {
                MyPictureBox = Dog2,
                RaceTrackLength = 530,
                Randomizer = MyRandomizer
            };

            greyhound[2] = new Greyhound()
            {
                MyPictureBox = Dog3,
                RaceTrackLength = 530,
                Randomizer = MyRandomizer
            };

            greyhound[3] = new Greyhound()
            {
                MyPictureBox = Dog4,
                RaceTrackLength = 530,
                Randomizer = MyRandomizer
            };

            guy[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = joeRadioButton, MyLabel = joeBetLabel };
            guy[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = bobRadioButton, MyLabel = bobBetLabel };
            guy[2] = new Guy() { Name = "Al", Cash = 45, MyRadioButton = alRadioButton, MyLabel = alBetLabel };                        
        }

        private void joeRadioButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myName.Text = guy[0].Name;
        }

        private void bobRadioButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myName.Text = guy[1].Name;
        }

        private void alRadioButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            myName.Text = guy[2].Name;
        }
        
        private void betButton_Click(object sender, RoutedEventArgs e)
        {
            int myBetAmount = Convert.ToInt32((((ComboBoxItem)betAmount.SelectedItem).Content).ToString());
            int myDog = Convert.ToInt32((((ComboBoxItem)dogSelection.SelectedItem).Content).ToString());
            if (joeRadioButton.IsChecked == true)
                guy[0].PlaceBet(myBetAmount, myDog);
            else if (bobRadioButton.IsChecked == true)
                guy[1].PlaceBet(myBetAmount, myDog);
            else if (alRadioButton.IsChecked == true)
                guy[2].PlaceBet(myBetAmount, myDog);
        }

        private async void RaceButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();            
            
            while(timer.IsRunning)
            {               
                for(int i=0; i < greyhound.Length; i++)
                {                    
                    if (greyhound[i].Run())
                    {                                                
                        timer.Stop();                        
                        winnerDog = i + 1;
                        winnerTextBlock.Text = "Dog #" + winnerDog + " won the damn race!";
                        okButton.Visibility = Visibility.Visible;                                                                                                                   
                    }

                    if (!timer.IsRunning)
                        break;

                    await Task.Delay(10);
                }
            }            
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            winnerTextBlock.Text = "";
            for (int j = 0; j < guy.Length; j++)
            {
                if (guy[j].MyBet != null)
                    guy[j].Collect(winnerDog); //To update cash of each of the guys
                guy[j].ClearBet(); //To change labels - has not placed bet
            }

            for (int k = 0; k < greyhound.Length; k++)
                greyhound[k].TakeStartingPosition();

            okButton.Visibility = Visibility.Collapsed;

            joeRadioButton.IsChecked = true;
        }
    }
}
