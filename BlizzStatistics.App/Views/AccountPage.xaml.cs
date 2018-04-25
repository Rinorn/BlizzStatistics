using System.Net.Http;
using Windows.UI.Xaml;
using ClassLibrary1;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlizzStatistics.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage
    {
        public string CharacterName;
        public string CharacterServer;
        public string[] Classes = {"Warrior", "Paladin", "Hunter", "Rogue", "Priest", "Death Knight", "Shaman", "Mage", "Warlock", "Monk", "Druid", "Demon Hunter"};
        public AccountPage()
        {
            InitializeComponent();
        }

        public async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CharacterName = CnameTextField.Text;
            CharacterServer = SBox.Text;
            var url = "https://eu.api.battle.net/wow/character/" + CharacterServer + "/" + CharacterName + "?locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye";
            var http = new HttpClient();
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<SavedCharacter>(result);
            int classIndex = data.Class;


            //Fungerer ikke.
            SavedCharacter character = new SavedCharacter()
            {
                Name = data.Name,
                Level = data.Level,
                ClassName = Classes[classIndex-1],
                Realm = data.Realm
            };
            try
            {
                await DataSource.SavedCharacters.Instance.AddSavedCharacter(character);
                
            }
            catch
            {
                // ignored
            }
        }
        
    }
}
