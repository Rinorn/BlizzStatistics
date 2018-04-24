using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ClassLibrary1;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlizzStatistics.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        
        public AccountPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CharacterRootobject Character = await GameCharacter.GetCharacter("Rinnorn", "Stormscale");
            TextBlock1.Text = Character.name;
            TextBlock2.Text = Character.realm;
            TextBlock3.Text = Character._class.ToString();
            TextBlock4.Text = Character.items.head.context;
            TextBlock5.Text = Character.items.head.appearance.itemAppearanceModId.ToString();
            TextBlock6.Text = Character.items.head.icon;
            TextBlock7.Text = Character.items.head.armor.ToString();
            TextBlock8.Text = Character.items.head.itemLevel.ToString();
            TextBlock9.Text = Character.items.head.stats[1].stat.ToString();
            TextBlock10.Text = Character.items.head.stats[1].amount.ToString();
        }
    }
}
