

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using Windows.Networking.BackgroundTransfer;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactions.Core;

namespace BlizzStatistics.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WoWPage
    {
        public WoWPage()
        {   
            
            InitializeComponent();
            
        }

        private void BtnLoadPage(object sender, RoutedEventArgs e)
        {
            var clickedBtn = sender as Button;
            DetermineBtn(clickedBtn);
        }

        private void DetermineBtn(Button btn)
        {
            if (btn == BtnLoadPagePvp)
            {
                Frame.Navigate(typeof(PvpPage));
            }else if (btn == BtnLoadPagePve)
            {
                Frame.Navigate(typeof(MythicView));
            }
            else if (btn == BtnLoadPageClasses)
            {
                Frame.Navigate(typeof(ClassPage));
            }
            else if (btn == BtnLoadPageRaces)
            {
                Frame.Navigate(typeof(RacePage));
            }
            else if (btn == BtnLoadPageOptimize)
            {
                Frame.Navigate(typeof(OptimizationPage));
            }
        }
    }
}
