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
        public string Url;
        public string Server;
        public string Char;
        public AccountPage()
        {
            this.InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Char = CnameTextblock.Text;
            Server = SBox.Text;
            Url ="https://eu.api.battle.net/wow/character/"+ Server +"/"+ Char +"?fields=items&locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye";
            
        }

        private async void GetChar(string Url)
        {
            try
            {
                
                var client = new HttpClient();
                var response = await client.GetStringAsync(Url);
                var data = JsonConvert.DeserializeObject<AddCharacter.CharacterRootobject>(response);
                GameCharacter Charcter = new GameCharacter();
                Charcter.CharacterName = data.name;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
            }
        }
    }
}
