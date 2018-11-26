using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BlizzStatistics.App.Views
{
    public sealed partial class Splash : UserControl
    {
        public Splash(SplashScreen splashScreen)
        {
            InitializeComponent();
            Window.Current.SizeChanged += (s, e) => Resize(splashScreen);
            Resize(splashScreen);
            Opacity = 0;
        }

        private void Resize(SplashScreen splashScreen)
        {
            if (splashScreen.ImageLocation.Top == 0)
            {
                return;
            }
            else
            {
                rootCanvas.Background = null;
            }
        }
    }
}
