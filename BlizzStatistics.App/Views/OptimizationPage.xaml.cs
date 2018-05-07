using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
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
        public string MainStatName;
        
        

        public OptimizationPage()
        {
            InitializeComponent();
        }

        private async void CharacterListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character = (SavedCharacter) CharacterListView.SelectedItem;
            if (Character != null) CharacterName = Character.Name;
            if (Character != null) CharacterServer = Character.Realm;
            DestroyGrid();
            
            await GetCharacterStats(CharacterName, CharacterServer);
            await GetCharacter(CharacterName, CharacterServer);
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
                MainStatName = "Intellect";
            }
            else if (charStatData.Stats.Agi > charStatData.Stats.Int &&
                     charStatData.Stats.Agi > charStatData.Stats.Str)
            {
                OriginalMainStat.Text = charStatData.Stats.Agi.ToString();
                OriginalMainStatBlock.Text = "Agility";
                OptimizedMainStatBlock.Text = "Agility";
                MainStatName = "Agility";
            }
            else
            {
                OriginalMainStat.Text = charStatData.Stats.Str.ToString();
                OriginalMainStatBlock.Text = "Strength";
                OptimizedMainStatBlock.Text = "Strength";
                MainStatName = "Strength";
            }
        }

        public  void DefineHeadSlot(GameCharacter data)
        {
            ItemThumbnail= data.Items.head.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            HeadSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtHeadSlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.head.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.head.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.head.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }

            var item = data.Items.head.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineNeckSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.neck.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            NeckSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 2;
            var mainGrid = TtNeckSlotGrid;
            for (var i = 0; i < 2; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.neck.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.neck.itemLevel;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.neck.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineShoulderSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.shoulder.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            ShoulderSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtShoulderSlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.shoulder.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.shoulder.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.shoulder.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.shoulder.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineBackSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.back.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            BackSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtBackSlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.back.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.back.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.back.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.back.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineChestSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.chest.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            ChestSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtChestSlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.chest.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.chest.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.chest.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.chest.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineBracerSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.wrist.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            BracerSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 2;
            var mainGrid = TtBracerSlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.wrist.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.wrist.itemLevel;
                        break;
                    
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.wrist.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineTrinket1Slot(GameCharacter data)
        {
            ItemThumbnail = data.Items.trinket1.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            Trinket1Slot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtTrinket1SlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.trinket1.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.trinket1.itemLevel;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.trinket1.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineGlovesSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.hands.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            GlovesSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtGlovesSlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.hands.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.hands.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.hands.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.hands.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineBeltSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.waist.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            BeltSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtBeltSlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.waist.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.waist.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.waist.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.waist.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineLegsSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.legs.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            LegsSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtLegsSlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.legs.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.legs.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.legs.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.legs.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineFeetSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.feet.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            FeetSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtFeetSlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.feet.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.feet.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.feet.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.feet.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineRing1Slot(GameCharacter data)
        {
            ItemThumbnail = data.Items.finger1.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            Ring1Slot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtRing1SlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.finger1.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.finger1.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.finger1.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.finger1.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineRing2Slot(GameCharacter data)
        {
            ItemThumbnail = data.Items.finger2.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            Ring2Slot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtRing2SlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.finger2.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.finger2.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.finger2.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.finger2.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineTrinket2Slot(GameCharacter data)
        {
            ItemThumbnail = data.Items.trinket2.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            Trinket2Slot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 3;
            var mainGrid = TtTrinket2SlotGrid;
            for (var i = 0; i < 3; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.trinket2.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.trinket2.itemLevel;
                        break;
                    default:
                        tbName.Text = "Armor " + data.Items.trinket2.armor;
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.trinket2.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineMainhandSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.mainHand.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            MainhandSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 4;
            var mainGrid = TtMainhandSlotGrid;
            for (var i = 0; i < 4; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.mainHand.name;
                        break;
                    case 1:
                        tbName.Text = "Item Level " + data.Items.mainHand.itemLevel;
                        break;
                    case 2:
                        tbName.Text = data.Items.mainHand.weaponInfo.damage.min + " - " +
                                      data.Items.mainHand.weaponInfo.damage.max + " Damage            Speed " + data.Items.mainHand.weaponInfo.weaponSpeed;
                        break;
                    case 3:
                        tbName.Text = data.Items.mainHand.weaponInfo.dps + " Damage per second";
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.shoulder.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        public void DefineOffhandSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.offHand == null ? data.Items.mainHand.icon : data.Items.offHand.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            OffhandSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 4;
            var mainGrid = TtOffhandSlotGrid;
            for (var i = 0; i < 4; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        if (data.Items.offHand != null) tbName.Text = data.Items.offHand.name;
                        break;
                    case 1:
                        if (data.Items.offHand != null) tbName.Text = "Item Level " + data.Items.offHand.itemLevel;
                        break;
                    case 2:
                        if (data.Items.offHand != null)
                            tbName.Text = data.Items.offHand.weaponInfo.damage.min + " - " +
                                          data.Items.offHand.weaponInfo.damage.max + " Damage            Speed " +
                                          data.Items.offHand.weaponInfo.weaponSpeed;
                        break;
                    case 3:
                        if (data.Items.offHand != null)
                            tbName.Text = data.Items.offHand.weaponInfo.dps + " Damage per second";
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i);
            }
            var item = data.Items.shoulder.stats;
            DefineStats(mainGrid, rowCount, item);
        }

        public void DefineStats(Grid mainGrid, int rowCount, Stat[] item) 
        {
            foreach (var a in item)
            {
                var g = new Grid();
                var tb = new TextBlock();
                switch (a.stat)
                {
                    case 74:
                    case 73:
                    case 71:
                    case 3:
                    case 4:
                    case 5:
                        tb.Text = " + " + a.amount + " " + MainStatName;
                        break;
                    case 40:
                        tb.Text = " + " + a.amount + " Versatility";
                        break;
                    case 49:
                        tb.Text = " + " + a.amount + " Mastery";
                        break;
                    case 62:
                        tb.Text = " + " + a.amount + " Leech";
                        break;
                    case 7:
                        tb.Text = " + " + a.amount + " Stamina";
                        break;
                    case 32:
                        tb.Text = " + " + a.amount + " Critical Strike";
                        break;
                    case 36:
                        tb.Text = " + " + a.amount + " Haste";
                        break;
                    case 61:
                        tb.Text = " + " + a.amount + " Speed";
                        break;
                    case 63:
                        tb.Text = " + " + a.amount + " Avoidance";
                        break;
                    case 64:
                        tb.Text = "Indestructible";
                        break;
                    default:
                        tb.Text = "Unidentified Stat";
                        break;
                }
                AddToGrid(g, tb, mainGrid, rowCount);
                rowCount++;
            }
        }
        public void AddToGrid(Grid g, TextBlock tb, Grid mainGrid, int rowCount)
        {
            g.Children.Add(tb);
            // Add the newly created Grid to the outer Grid
            var rowHeight = new RowDefinition { Height = new GridLength(15) };
            mainGrid.RowDefinitions.Add(rowHeight);
            Grid.SetRow(g, rowCount);
            Grid.SetColumn(g, 0);
            mainGrid.Children.Add(g);

        }
        private void DestroyGrid()
        {
            TtMainhandSlotGrid.Children.Clear();
            TtOffhandSlotGrid.Children.Clear();
            TtTrinket2SlotGrid.Children.Clear();
            TtRing2SlotGrid.Children.Clear();
            TtRing1SlotGrid.Children.Clear();
            TtFeetSlotGrid.Children.Clear();
            TtLegsSlotGrid.Children.Clear();
            TtBeltSlotGrid.Children.Clear();
            TtGlovesSlotGrid.Children.Clear();
            TtTrinket1SlotGrid.Children.Clear();
            TtBracerSlotGrid.Children.Clear();
            TtChestSlotGrid.Children.Clear();
            TtBackSlotGrid.Children.Clear();
            TtShoulderSlotGrid.Children.Clear();
            TtNeckSlotGrid.Children.Clear();
            TtHeadSlotGrid.Children.Clear();
        }
    }
}
