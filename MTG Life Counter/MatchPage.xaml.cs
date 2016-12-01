using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MTG_Life_Counter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MatchPage : Page
    {

        public MatchPage()
        {
            this.InitializeComponent();            

            var lifeObj = App.Current as App;

            player1HP.Text = lifeObj.lifePointsA.ToString();
            player2HP.Text = lifeObj.lifePointsB.ToString();

            poisonTextA.Text = lifeObj.poisonCountersA.ToString();
            poisonTextB.Text = lifeObj.poisonCountersB.ToString();

        }



        // player 1 HP modification events
        private void sub1a_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;
            lifeObj.lifePointsA--;            

            player1HP.Text = lifeObj.lifePointsA.ToString();

        }

        private void add1a_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;
            lifeObj.lifePointsA++;
            
            player1HP.Text = lifeObj.lifePointsA.ToString();
        }

        private void sub5a_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;
            lifeObj.lifePointsA = lifeObj.lifePointsA - 5;

            player1HP.Text = lifeObj.lifePointsA.ToString();
        }

        private void add5a_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;
            lifeObj.lifePointsA = lifeObj.lifePointsA + 5;

            player1HP.Text = lifeObj.lifePointsA.ToString();
        }

        //player 2 HP modification events
        private void sub1b_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;
            lifeObj.lifePointsB--;

            player2HP.Text = lifeObj.lifePointsB.ToString();
        }

        private void add1b_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;
            lifeObj.lifePointsB++;

            player2HP.Text = lifeObj.lifePointsB.ToString();
        }

        private void sub5b_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;
            lifeObj.lifePointsB = lifeObj.lifePointsB - 5;

            player2HP.Text = lifeObj.lifePointsB.ToString();
        }

        private void add5b_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;
            lifeObj.lifePointsB = lifeObj.lifePointsB + 5;

            player2HP.Text = lifeObj.lifePointsB.ToString();
        }

        //poison
        //player 1
        private void subPoisA_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;

            lifeObj.poisonCountersA--;
            if (lifeObj.poisonCountersA <= 0)
            {
                lifeObj.poisonCountersA = 0;
            }
            poisonTextA.Text = lifeObj.poisonCountersA.ToString();
        }

        private void addPoisA_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;

            lifeObj.poisonCountersA++;
            poisonTextA.Text = lifeObj.poisonCountersA.ToString();
        }

        //player 2
        private void subPoisB_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;

            lifeObj.poisonCountersB--;
            if (lifeObj.poisonCountersB <= 0)
            {
                lifeObj.poisonCountersB = 0;
            }
            poisonTextB.Text = lifeObj.poisonCountersB.ToString();
        }

        private void addPoisB_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;

            lifeObj.poisonCountersB++;
            poisonTextB.Text = lifeObj.poisonCountersB.ToString();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            var lifeObj = App.Current as App;
            lifeObj.lifePointsA = lifeObj.resetPoints;
            lifeObj.lifePointsB = lifeObj.resetPoints;
            lifeObj.poisonCountersA = 0;
            lifeObj.poisonCountersB = 0;
            player1HP.Text = lifeObj.resetPoints.ToString();
            player2HP.Text = lifeObj.resetPoints.ToString();
            poisonTextA.Text = 0.ToString();
            poisonTextB.Text = 0.ToString();

        }

        private void img1_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackgroundImage("Assets/bg_1.jpg");
        }

        private void img2_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackgroundImage("Assets/bg_2.jpg");
        }

        private void img3_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackgroundImage("Assets/bg_3.jpg");
        }

        private void img4_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackgroundImage("Assets/bg_4.jpg");
        }

        private void img5_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackgroundImage("Assets/bg_5.jpg");
        }

        private void appBarButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
            Windows.ApplicationModel.DataTransfer.DataTransferManager.GetForCurrentView().DataRequested += MainPage_DataRequested;
        }

        void MainPage_DataRequested(Windows.ApplicationModel.DataTransfer.DataTransferManager sender, Windows.ApplicationModel.DataTransfer.DataRequestedEventArgs args)
        {
            //ATENTION!!! CHANGE THE URI WHEN YOU OBTAIN THE STORE ID OF THIS APP!
            Uri URI = new Uri("https://www.microsoft.com/store/apps/9NBLGGH526XJ");
            args.Request.Data.SetWebLink(URI);
            args.Request.Data.Properties.Title = "MTG Simple Life Counter";
            args.Request.Data.Properties.Description = "This application will keep the score and current situation of Magic The Gathering match.";
        }

        private void infoAppButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(info));
        }

        private void HP20InitBtn_Click(object sender, RoutedEventArgs e)
        {
            AlertBox(20);
        }

        private void HP40InitBtn_Click(object sender, RoutedEventArgs e)
        {
            AlertBox(40);
        }



        // Custom Methods ------------------<-<-<-<

        private async void AlertBox(int hpValue)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Start New Match?",
                Content = "This will reset the values. Continue?",
                PrimaryButtonText = "No",
                SecondaryButtonText = "Yes"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();

            if (result == ContentDialogResult.Secondary)
            {
                var lifeObj = App.Current as App;

                lifeObj.lifePointsA = hpValue;
                lifeObj.lifePointsB = hpValue;

                player1HP.Text = lifeObj.lifePointsA.ToString();
                player2HP.Text = lifeObj.lifePointsB.ToString();

                lifeObj.resetPoints = hpValue;
            }
        }

        private void ChangeBackgroundImage(string imgUri)
        {
            main.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(this.BaseUri, imgUri)), Stretch = Stretch.Fill };
        }
    }
}
