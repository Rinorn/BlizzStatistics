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
                /*
                HeadSlot = data.Items.head.id,
                NeckSlot = data.Items.neck.id,
                ShoulderSlot = data.Items.neck.id,
                BackSlot = data.Items.back.id,
                ChestSlot = data.Items.chest.id,
                WristSlot = data.Items.wrist.id,
                GlovesSlot = data.Items.hands.id,
                BeltSlot = data.Items.waist.id,
                LegsSlot = data.Items.legs.id,
                FeetSlot = data.Items.feet.id,
                Ring1Slot = data.Items.finger1.id,
                Ring2Slot = data.Items.finger2.id,
                Trinket1Slot = data.Items.trinket1.id,
                Trinket2Slot = data.Items.trinket2.id,
                MainHandSlot = data.Items.mainHand.id,
                OffhandSlot = data.Items.offHand.id */
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
