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
        /// <summary>
        /// The character name
        /// </summary>
        private string _characterName;
        /// <summary>
        /// The character server
        /// </summary>
        private string _characterServer;
        /// <summary>
        /// The classes
        /// </summary>
        private readonly string[] _classes = {"Warrior", "Paladin", "Hunter", "Rogue", "Priest", "Death Knight", "Shaman", "Mage", "Warlock", "Monk", "Druid", "Demon Hunter"};

        public string CharacterName1 { get => _characterName; set => _characterName = value; }
        public string CharacterServer1 { get => _characterServer; set => _characterServer = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPage"/> class.
        /// </summary>
        public AccountPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the OnClick event of the ButtonBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e")]
        public async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CharacterName1 = CnameTextField.Text;
            CharacterServer1 = SBox.Text;
            var url = "https://eu.api.battle.net/wow/character/" + CharacterServer1 + "/" + CharacterName1 + "?fields=items&locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye";
            var http = new HttpClient();
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<GameCharacter>(result);
            var classIndex = data.Class;
            
            var character = new SavedCharacter()
            {
                Name = data.Name,
                Level = data.Level,
                ClassName = _classes[classIndex-1],
                Realm = data.Realm,
                
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
