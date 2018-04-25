using System;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using ClassLibrary1;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlizzStatistics.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OptimizationPage : Page
    {
        public SavedCharacter Character;
        public string CharacterName;
        public string CharacterServer;
        public string ItemUrl1 = "https://wow.zamimg.com/images/wow/icons/large/";
        public string ItemUrl2 = ".jpg";
        public string ItemThumbnail;
        public string CombinedUrl;
        
        public OptimizationPage()
        {
            this.InitializeComponent();
        }

        private async void CharacterListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character = (SavedCharacter) CharacterListView.SelectedItem;
            if (Character != null) CharacterName = Character.name;
            if (Character != null) CharacterServer = Character.realm;

            await GetCharacter(CharacterName, CharacterServer);
            await GetCharacterStats(CharacterName, CharacterServer);
        }
        public  async Task<GameCharacter> GetCharacter(string name, string server)
        {
            try
            {
                var http = new HttpClient();

            var response = await http.GetAsync("https://eu.api.battle.net/wow/character/" + server + "/" + name + "?fields=items&locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye");
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<GameCharacter>(result);
            
                DefineHeadSlot(data);
                DefineNeckSlot(data);
                DefineShoulderSlot(data);
                DefineBackSlot(data);
                DefineChestSlot(data);
                DefineBracerSlot(data);
                DefineTrinket1Slot(data);
                DefineGlovesSlot(data);
                DefineBeltSlot(data);
                DefineLegsSlot(data);
                DefineFeetSlot(data);
                DefineRing1Slot(data);
                DefineRing2Slot(data);
                DefineTrinket2Slot(data);
                DefineMainhandSlot(data);
                DefineOffhandSlot(data);
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }

        public async Task<OriginalCharacterStats> GetCharacterStats(string name, string server)
        {
            var http = new HttpClient();

            var response = await http.GetAsync("https://eu.api.battle.net/wow/character/" + server + "/" + name + "?fields=stats&locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye");
            var result = await response.Content.ReadAsStringAsync();
            var charStatData = JsonConvert.DeserializeObject<OriginalCharacterStats>(result);

            CheckMainStat(charStatData);
            OriginalClassResource.Text = charStatData.stats.power.ToString();
            OriginalClassResourceBlock.Text = charStatData.stats.powerType;
            OriginalCrit.Text = charStatData.stats.critRating.ToString();
            OriginalHaste.Text = charStatData.stats.hasteRating.ToString();
            OriginalHitpoints.Text = charStatData.stats.health.ToString();
            OriginalMastery.Text = charStatData.stats.masteryRating.ToString();
            OriginalStamina.Text = charStatData.stats.sta.ToString();
            OriginalVersatility.Text = charStatData.stats.versatility.ToString();
            return charStatData;
        }

        public void CheckMainStat(OriginalCharacterStats charStatData)
        {
            if (charStatData.stats.Int > charStatData.stats.agi && charStatData.stats.Int > charStatData.stats.str)
            {
                OriginalMainStat.Text = charStatData.stats.Int.ToString();
                OriginalMainStatBlock.Text = "Intellect";
            }
            else if (charStatData.stats.agi > charStatData.stats.Int &&
                     charStatData.stats.agi > charStatData.stats.str)
            {
                OriginalMainStat.Text = charStatData.stats.agi.ToString();
                OriginalMainStatBlock.Text = "Agility";
            }
            else
            {
                OriginalMainStat.Text = charStatData.stats.str.ToString();
                OriginalMainStatBlock.Text = "Strength";
            }
        }

        public  void DefineHeadSlot(GameCharacter data)
        {
            ItemThumbnail= data.items.head.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            HeadSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineNeckSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.neck.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            NeckSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineShoulderSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.shoulder.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            ShoulderSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineBackSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.back.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            BackSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineChestSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.chest.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            ChestSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineBracerSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.wrist.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            BracerSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineTrinket1Slot(GameCharacter data)
        {
            ItemThumbnail = data.items.trinket1.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            Trinket1Slot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineGlovesSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.hands.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            GlovesSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineBeltSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.waist.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            BeltSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineLegsSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.legs.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            LegsSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineFeetSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.feet.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            FeetSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineRing1Slot(GameCharacter data)
        {
            ItemThumbnail = data.items.finger1.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            Ring1Slot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineRing2Slot(GameCharacter data)
        {
            ItemThumbnail = data.items.finger2.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            Ring2Slot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineTrinket2Slot(GameCharacter data)
        {
            ItemThumbnail = data.items.trinket2.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            Trinket2Slot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineMainhandSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.mainHand.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            MainhandSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
        public void DefineOffhandSlot(GameCharacter data)
        {
            ItemThumbnail = data.items.offHand == null ? data.items.mainHand.icon : data.items.offHand.icon;
            
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            OffhandSlot.Source = new BitmapImage(new Uri(CombinedUrl));
        }
    }
}
