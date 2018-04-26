using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using ClassLibrary1;
using Newtonsoft.Json;



namespace BlizzStatistics.App.Views
{
    //This page is not finished, i am currently trying to work out how the optimizating part will work, therefore the page is not commented yet.
    public sealed partial class OptimizationPage
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
            InitializeComponent();
        }

        private async void CharacterListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character = (SavedCharacter) CharacterListView.SelectedItem;
            if (Character != null) CharacterName = Character.Name;
            if (Character != null) CharacterServer = Character.Realm;

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
            SetOriginalStats(charStatData);
            CheckOptimizedMainStats(charStatData);
            SetOptimizedStats(charStatData);
            return charStatData;
        }

        public void CheckOptimizedMainStats(OriginalCharacterStats data)
        {
            if (OptimizedMainStatBlock.Text.Equals("Intellect"))
            {
                OptimizedMainStatBox.Text = data.Stats.Int.ToString();
            }else if (OptimizedMainStatBlock.Text.Equals("Agility"))
            {
                OptimizedMainStatBox.Text = data.Stats.Agi.ToString();
            }
            else
            {
                OptimizedMainStatBox.Text = data.Stats.Str.ToString();
            }
        }
        //Placeholder values for the optimized stats. there will need to be some kind of calculation done here
        public void SetOptimizedStats(OriginalCharacterStats charStatData)
        {
            OptimizedClassResourceBox.Text = charStatData.Stats.Power.ToString();
            OptimizedClassResourceBlock.Text = charStatData.Stats.PowerType;
            OptimizedCritBox.Text = charStatData.Stats.CritRating.ToString();
            OptimizedHasteBox.Text = charStatData.Stats.HasteRating.ToString();
            OptimizedHpBox.Text = charStatData.Stats.Health.ToString();
            OptimizedMasteryBox.Text = charStatData.Stats.MasteryRating.ToString();
            OptimizedStaminaBox.Text = charStatData.Stats.Sta.ToString();
            OptimizedVersatilityBox.Text = charStatData.Stats.Versatility.ToString();

        }

        public void SetOriginalStats(OriginalCharacterStats charStatData)
        {
            OriginalClassResource.Text = charStatData.Stats.Power.ToString();
            OriginalClassResourceBlock.Text = charStatData.Stats.PowerType;
            OriginalCrit.Text = charStatData.Stats.CritRating.ToString();
            OriginalHaste.Text = charStatData.Stats.HasteRating.ToString();
            OriginalHitpoints.Text = charStatData.Stats.Health.ToString();
            OriginalMastery.Text = charStatData.Stats.MasteryRating.ToString();
            OriginalStamina.Text = charStatData.Stats.Sta.ToString();
            OriginalVersatility.Text = charStatData.Stats.Versatility.ToString();
        }

        public void CheckMainStat(OriginalCharacterStats charStatData)
        {
            if (charStatData.Stats.Int > charStatData.Stats.Agi && charStatData.Stats.Int > charStatData.Stats.Str)
            {
                OriginalMainStat.Text = charStatData.Stats.Int.ToString();
                OriginalMainStatBlock.Text = "Intellect";
                OptimizedMainStatBlock.Text = "Intellect";
            }
            else if (charStatData.Stats.Agi > charStatData.Stats.Int &&
                     charStatData.Stats.Agi > charStatData.Stats.Str)
            {
                OriginalMainStat.Text = charStatData.Stats.Agi.ToString();
                OriginalMainStatBlock.Text = "Agility";
                OptimizedMainStatBlock.Text = "Agility";
            }
            else
            {
                OriginalMainStat.Text = charStatData.Stats.Str.ToString();
                OriginalMainStatBlock.Text = "Strength";
                OptimizedMainStatBlock.Text = "Strength";
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
