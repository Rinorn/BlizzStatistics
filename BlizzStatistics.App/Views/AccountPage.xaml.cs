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
        public string CharacterName;
        public string CharacterServer;
        public string[] classes = {"Warrior", "Paladin", "Hunter", "Rogue", "Priest", "Death Knight", "Shaman", "Mage", "Warlock", "Monk", "Druid", "Demon Hunter"};
        public AccountPage()
        {
            this.InitializeComponent();
        }

        public async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CharacterName = CnameTextField.Text;
            CharacterServer = SBox.Text;
            var url = "https://eu.api.battle.net/wow/character/" + CharacterServer + "/" + CharacterName + "?locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7y";
            var http = new HttpClient();
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<SavedCharacter>(result);
            int test = data._class;


            //Fungerer ikke.
            SavedCharacter character = new SavedCharacter()
            {
                name = data.name,
                level = data.level,
                ClassName = classes[test],
                realm = data.realm
            };
            try
            {
                await DataSource.SavedCharacters.Instance.AddSavedCharacter(character);
            }
            catch 
            {
                
            }
            
        }
        
    }
}
