using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using BlizzStatistics.App.ViewModels;
using ClassLibrary1;
using Newtonsoft.Json;


namespace BlizzStatistics.App.Views
{
    
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
        public List<Equipment> Equipment;
        public int SelectedCharacterArmorType;
        private GameCharacter _selectedChar;
        private int _itemSlot;
        private Image _clickedImage;
        private Grid _clickedImgGrid;
        private Equipment _selectedEquipment;
        private int _mainStatIndex;
        private Stat[] _selectedItemStats;
        private int _orgMainStatValue;
        private int _orgStaminaValue;
        private int _orgMasteryValue;
        private int _orgHasteValue;
        private int _orgCritValue;
        private int _orgVersatilityValue;
        private int _saveToDbIndex;
        private readonly BitmapImage _defaultImg = new BitmapImage(new Uri("http://localhost:60158/api/images/add.jpg/"));
        private int[] _slotArray;
        private int _gearSlotOffset;


        /// <summary>
        /// An Array Containing the Playable Classes
        /// </summary>
        private readonly string[] _classes = { "Warrior", "Paladin", "Hunter", "Rogue", "Priest", "Death Knight", "Shaman", "Mage", "Warlock", "Monk", "Druid", "Demon Hunter" };


        /// <summary>
        /// Enum used To get the playable classes armortype.
        /// </summary>
        enum ClassArmorType{ Plate = 4, Mail = 3, Leather = 2, Cloth = 1}

        public OptimizationPage(){ InitializeComponent();}

        /// <summary>
        /// Handles the OnSelectionChanged event of the CharacterListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void CharacterListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetOverlayStatus(true);
            _slotArray = new int[14];
            if (CharacterListView.SelectedItem == null){ CharacterListView.SelectedIndex = 0;}
            Character = (SavedCharacter)CharacterListView.SelectedItem;
            if (Character != null) CharacterName = Character.Name;
            if (Character != null) CharacterServer = Character.Realm;
            DestroyChildren();
            try
            {
                await GetCharacterStats(CharacterName, CharacterServer);
                await GetCharacter(CharacterName, CharacterServer);
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.Message + "\nSomething went wrong when retrieving the selected character. Please try again later");
                await msg.ShowAsync();
                await LogToDbAsync(ex);
            }
            SetOverlayStatus(false);
        }

        /// <summary>
        /// Logs to database asynchronous.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        private static async Task LogToDbAsync(Exception e)
        {
            var exception = new ExceptionHandler()
            {
                Message = e.Message,
                StackTrace = e.StackTrace,
                ExceptionSource = e.Source,
                Logdate = DateTime.UtcNow
            };
            await DataSource.ExceptionHandlers.Instance.AddExceptionHandler(exception);
        }

        /// <summary>
        /// Gets all data about the selectet character from the blizzard api 
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="server">The server.</param>
        /// <returns></returns>
        public async  Task<GameCharacter> GetCharacter(string name, string server)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var response = await http.GetAsync("https://eu.api.battle.net/wow/character/" + server + "/" + name + "?fields=items&locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye");
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<GameCharacter>(result);
                    await DefineItemSlotsAsync(data);
                    return data;
                }
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.Message + "\nUnable to establish connection to Blizzard Entertainment's database. Please try again later");
                await msg.ShowAsync();
                await LogToDbAsync(ex);
            }
            return null;
        }

        /// <summary>
        /// Calles a define function for every gearslot a Character can have. also calls a function that checks if the character has any saved gear in the db.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private async Task DefineItemSlotsAsync(GameCharacter data)
        {
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
            _selectedChar = data;
            await CheckForSavedGear();
        }
        /// <summary>
        /// Gets a Original Character object from the Blizzard api that contains the statistics for the currently selected character. Then calls for functions to treat the data.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="server">The server.</param>
        /// <returns></returns>
        public async Task<OriginalCharacterStats> GetCharacterStats(string name, string server)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var response = await http.GetAsync("https://eu.api.battle.net/wow/character/" + server + "/" + name + "?fields=stats&locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye");
                    var result = await response.Content.ReadAsStringAsync();
                    var charStatData = JsonConvert.DeserializeObject<OriginalCharacterStats>(result);
                    CheckMainStat(charStatData);
                    SetOriginalStats(charStatData);
                    CheckOptimizedMainStats(charStatData);
                    SetOptimizedStats(charStatData);
                    return charStatData;
                }
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.Message + "\nUnable to establish connection to Blizzard Entertainment's database. Please try again later");
                await msg.ShowAsync();
                await LogToDbAsync(ex);
            }
            return null;
        }

        /// <summary>
        /// Checks the OptimizedMainStatBlock.Text value and sets the OptimizedMainStatBlock.Text to be the characters mainstat
        /// </summary>
        /// <param name="data">The data.</param>
        public void CheckOptimizedMainStats(OriginalCharacterStats data)
        {
            if (OptimizedMainStatBlock.Text.Equals("Intellect"))
            {
                OptimizedMainStatBox.Text = data.Stats.Int.ToString();
                _mainStatIndex = 1;
            }else if (OptimizedMainStatBlock.Text.Equals("Agility"))
            {
                OptimizedMainStatBox.Text = data.Stats.Agi.ToString();
                _mainStatIndex = 2;
            }
            else
            {
                OptimizedMainStatBox.Text = data.Stats.Str.ToString();
                _mainStatIndex = 3;
            }
        }
        /// <summary>
        /// Sets the optimized stats to be equal to the Original stats. This is to have a Base to correctly calculate the Optimized stats later on. 
        /// </summary>
        /// <param name="charStatData">The character stat data.</param>
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

        /// <summary>
        /// Sets the original stats.
        /// </summary>
        /// <param name="charStatData">The character stat data.</param>
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

        /// <summary>
        /// Checks the 3 "MainStats" a character has. (The Highest one will be the Character Mainstat thats worked with in this app.) This is to decide if the character is a Strengt, intellect or Agilitybased character.
        /// </summary>
        /// <param name="charStatData">The character stat data.</param>
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

        /// <summary>
        /// Sets the Original headslotBox image source to be the characters equipt helmet image. then it calls AddToGrid and DefineStats to add the gear statsand name to the grid inside the headslotBox's ToolTip
        /// </summary>
        /// <param name="data">The data.</param>
        public void DefineHeadSlot(GameCharacter data)
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }

            var item = data.Items.head.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the neckslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.neck.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Shoulderslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.shoulder.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Backslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.back.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Chestslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.chest.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Bracerslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.wrist.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Trinket1slotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.trinket1.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Glovesslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.hands.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Beltslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.waist.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Legsslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.legs.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Feetslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.feet.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Ring1slotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.finger1.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Ring2slotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i,15);
            }
            var item = data.Items.finger2.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Trinket2slotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.trinket2.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Mainhandslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
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
                AddToGrid(b, tbName, mainGrid, i, 15);
            }
            var item = data.Items.mainHand.stats;
            DefineStats(mainGrid, rowCount, item);
        }
        /// <summary>
        /// Same as DefineHeadSlot, but for the Offhandslotbox.
        /// </summary>
        /// <param name="data">The data.</param>
        public void DefineOffhandSlot(GameCharacter data)
        {
            ItemThumbnail = data.Items.offHand == null ? data.Items.mainHand.icon : data.Items.offHand.icon;
            CombinedUrl = ItemUrl1 + ItemThumbnail + ItemUrl2;
            OffhandSlot.Source = new BitmapImage(new Uri(CombinedUrl));
            var rowCount = 4;
            var rowOffsett = 0;
            var mainGrid = TtOffhandSlotGrid;
            for (var i = 0; i < 4; i++)
            {
                var b = new Grid();
                var tbName = new TextBlock();
                switch (i)
                {
                    case 0:
                        tbName.Text = data.Items.offHand == null ? data.Items.mainHand.name : data.Items.offHand.name;
                        break;
                    case 1:
                        tbName.Text = data.Items.offHand == null ? "Item Level " +  data.Items.mainHand.itemLevel : "Item Level " + data.Items.offHand.itemLevel;
                        break;
                    case 2:
                        if (data.Items.offHand == null)
                        {
                            tbName.Text = data.Items.mainHand.weaponInfo.damage.min + " - " +
                                          data.Items.mainHand.weaponInfo.damage.max + " Damage            Speed " +
                                          data.Items.mainHand.weaponInfo.weaponSpeed;
                        }
                        else
                        {
                            if (data.Items.offHand.weaponInfo != null)
                            {
                                tbName.Text = data.Items.offHand.weaponInfo.damage.min + " - " +
                                              data.Items.offHand.weaponInfo.damage.max + " Damage            Speed " +
                                              data.Items.offHand.weaponInfo.weaponSpeed;
                            }
                            else
                            {
                                rowOffsett = 1;
                                continue;
                            }
                        }     
                        break;
                    case 3:
                        if (data.Items.offHand == null)
                        {
                            tbName.Text = data.Items.mainHand.weaponInfo.dps + " Damage per second";
                        }
                        else
                        {
                            if (data.Items.offHand.weaponInfo != null)
                            {
                                tbName.Text = data.Items.offHand.weaponInfo.dps + " Damage per second";
                            }
                            else
                            {
                                tbName.Text = "Armor " + data.Items.offHand.armor;
                            }
                        } 
                        break;
                }
                AddToGrid(b, tbName, mainGrid, i-rowOffsett, 15);
            }
            var item = data.Items.offHand == null ? data.Items.mainHand.stats : data.Items.offHand.stats;
            DefineStats(mainGrid, rowCount-rowOffsett, item);
        }

        /// <summary>
        /// Defines the stats.The stats are saved with id and not the statName in the blizzard db. Therefor this function is needed to find out which statname the stat has, and to set the stat value and name to a temporary tb that then added to the tooltip grid for the selected itemslotBox.
        /// </summary>
        /// <param name="mainGrid">The main grid.</param>
        /// <param name="rowCount">The row count.</param>
        /// <param name="item">The item.</param>
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
                AddToGrid(g, tb, mainGrid, rowCount,15);
                rowCount++;
            }
        }
        /// <summary>
        /// Adds a textblock to a tooltip grid.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="tb">The tb.</param>
        /// <param name="mainGrid">The main grid.</param>
        /// <param name="rowCount">The row count.</param>
        /// <param name="prefRowHeight">Height of the preference row.</param>
        public void AddToGrid(Grid g, TextBlock tb, Grid mainGrid, int rowCount, int prefRowHeight)
        {
            g.Children.Add(tb);
            // Add the newly created Grid to the outer Grid
            var rowHeight = new RowDefinition { Height = new GridLength(prefRowHeight) };
            mainGrid.RowDefinitions.Add(rowHeight);
            Grid.SetRow(g, rowCount);
            Grid.SetColumn(g, 0);
            mainGrid.Children.Add(g);

        }
        /// <summary>
        /// Removes all elements from the  Original gearboxes. this is so that the ToolTips can be defined again in the same way
        /// </summary>
        private void DestroyChildren()
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
            DestroyRowDef();
        }

        /// <summary>
        /// Destroys the row definitions from the Original gearbox's Tooltips.
        /// </summary>
        private void DestroyRowDef()
        {
            TtMainhandSlotGrid.RowDefinitions.Clear();
            TtOffhandSlotGrid.RowDefinitions.Clear();
            TtTrinket2SlotGrid.RowDefinitions.Clear();
            TtRing2SlotGrid.RowDefinitions.Clear();
            TtRing1SlotGrid.RowDefinitions.Clear();
            TtFeetSlotGrid.RowDefinitions.Clear();
            TtLegsSlotGrid.RowDefinitions.Clear();
            TtBeltSlotGrid.RowDefinitions.Clear();
            TtGlovesSlotGrid.RowDefinitions.Clear();
            TtTrinket1SlotGrid.RowDefinitions.Clear();
            TtBracerSlotGrid.RowDefinitions.Clear();
            TtChestSlotGrid.RowDefinitions.Clear();
            TtBackSlotGrid.RowDefinitions.Clear();
            TtShoulderSlotGrid.RowDefinitions.Clear();
            TtNeckSlotGrid.RowDefinitions.Clear();
            TtHeadSlotGrid.RowDefinitions.Clear();
        }

        /// <summary>
        /// This is called when the user clicks one of the Optimize Gearbox's. calls 3 functions to define which box that was pressed, what armortype the selected character used and what items that should be shown in the ItemContentDialog.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void BtnShowItemList(object sender, RoutedEventArgs e)
        {
            try
            {
                var clickedBtn = sender as Button;
                DefineItemSlots(clickedBtn);
                DefineArmorType();
                FillOptItemList(SelectedCharacterArmorType);
                await ItemContentDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.Message + "\nSomething went wrong during the loading of the item list for the selected itemslot.");
                await msg.ShowAsync();
                await LogToDbAsync(ex);
            }
        }

        /// <summary>
        /// Adds items to Itemlist based on the criteria from BtnShowItemList.
        /// </summary>
        /// <param name="armorType">Type of the armor.</param>
        private async void FillOptItemList(int armorType)
        {
            if (Equipment == null){Equipment = new List<Equipment>(await DataSource.Equipments.Instance.GetEquipment()); }
            var view = new OptimizationViewModel {Equipments = new ObservableCollection<Equipment>()};
            foreach (var a in Equipment)
            {
                if (a.ArmorType == armorType && a.RestrictedToClass == 0 || a.ArmorType == armorType && a.RestrictedToClass == _selectedChar.Class)
                {
                    if (a.Slot == _itemSlot)
                    {
                        view.Equipments.Add(a);
                    }
                }
                else if (a.ArmorType == 0 && a.Slot == _itemSlot && a.RestrictedToStat == 0)
                {
                    view.Equipments.Add(a);
                }
                else if (a.ArmorType == 1 && a.Slot == _itemSlot)
                {
                    if (_itemSlot == 16)
                    {
                        view.Equipments.Add(a);
                    }
                }
                else if (a.ArmorType == 0 && a.Slot == _itemSlot && a.RestrictedToStat != 0)
                {
                    if (a.RestrictedToStat == _mainStatIndex || a.RestrictedToStat == 4 && _mainStatIndex == 2 ||
                        a.RestrictedToStat == 4 && _mainStatIndex == 3)
                    {
                        view.Equipments.Add(a);
                    }
                }  
            }
            ItemList.ItemsSource = view.Equipments;
        }

        /// <summary>
        /// Defines the item slots. sets the itemslot, what image the clicked button belongs to, what ToolTip grid that belongs to the image, and the current stats for the currently equipted item the of the Character.
        /// </summary>
        /// <param name="clickedBtn">The clicked BTN.</param>
        private void DefineItemSlots(Button clickedBtn)
        {
            if (clickedBtn == BtnHeadSlot){_itemSlot = 1; _gearSlotOffset = 0; _saveToDbIndex = 1; _clickedImage = OptHeadSlotImg; _clickedImgGrid = OptTtHeadSlotGrid; _selectedItemStats = _selectedChar.Items.head.stats;}
            else if (clickedBtn == BtnNeckSlot){_itemSlot = 2; _gearSlotOffset = 0; _saveToDbIndex = 2; _clickedImage = OptNeckSlotImg; _clickedImgGrid = OptTtNeckSlotGrid; _selectedItemStats = _selectedChar.Items.neck.stats;}
            else if (clickedBtn == BtnShoulderSlot){_itemSlot = 3; _gearSlotOffset = 0; _saveToDbIndex = 3; _clickedImage = OptShoulderSlotImg; _clickedImgGrid = OptTtShoulderSlotGrid; _selectedItemStats = _selectedChar.Items.shoulder.stats;}
            else if (clickedBtn == BtnBackSlot){_itemSlot = 16; _gearSlotOffset = 0; _saveToDbIndex = 4; _clickedImage = OptBackSlotImg; _clickedImgGrid = OptTtBackSlotGrid; _selectedItemStats = _selectedChar.Items.back.stats;}
            else if (clickedBtn == BtnChestSlot){_itemSlot = 5; _gearSlotOffset = 0; _saveToDbIndex = 5; _clickedImage = OptChestSlotImg; _clickedImgGrid = OptTtChestSlotGrid; _selectedItemStats = _selectedChar.Items.chest.stats;}
            else if (clickedBtn == BtnBeltSlot){_itemSlot = 6; _gearSlotOffset = 0; _saveToDbIndex = 6; _clickedImage = OptBeltSlotImg; _clickedImgGrid = OptTtBeltSlotGrid; _selectedItemStats = _selectedChar.Items.waist.stats;}
            else if (clickedBtn == BtnLegsSlot){_itemSlot = 7; _gearSlotOffset = 0; _saveToDbIndex = 7; _clickedImage = OptLegsSlotImg; _clickedImgGrid = OptTtLegsSlotGrid; _selectedItemStats = _selectedChar.Items.legs.stats;}
            else if (clickedBtn == BtnFeetSlot){_itemSlot = 8; _gearSlotOffset = 0; _saveToDbIndex = 8; _clickedImage = OptFeetSlotImg; _clickedImgGrid = OptTtFeetSlotGrid; _selectedItemStats = _selectedChar.Items.feet.stats;}
            else if (clickedBtn == BtnWristSlot){_itemSlot = 9; _gearSlotOffset = 0; _saveToDbIndex = 9; _clickedImage = OptWristSlotImg; _clickedImgGrid = OptTtWristSlotGrid; _selectedItemStats = _selectedChar.Items.wrist.stats;}
            else if (clickedBtn == BtnGlovesSlot){_itemSlot = 10; _gearSlotOffset = 0; _saveToDbIndex = 10; _clickedImage = OptGlovesSlotImg; _clickedImgGrid = OptTtGlovesSlotGrid; _selectedItemStats = _selectedChar.Items.hands.stats;}
            else if (clickedBtn == BtnRing1Slot){_itemSlot = 11; _gearSlotOffset = 0; _saveToDbIndex = 11; _clickedImage = OptRing1SlotImg; _clickedImgGrid = OptTtRing1SlotGrid; _selectedItemStats = _selectedChar.Items.finger1.stats;}
            else if (clickedBtn == BtnRing2Slot){_itemSlot = 11; _gearSlotOffset = 3; _saveToDbIndex = 12; _clickedImage = OptRing2SlotImg; _clickedImgGrid = OptTtRing2SlotGrid; _selectedItemStats = _selectedChar.Items.finger2.stats;}
            else if (clickedBtn == BtnTrinket1Slot){_itemSlot = 12; _gearSlotOffset = 0; _saveToDbIndex = 13; _clickedImage = OptTrinket1SlotImg; _clickedImgGrid = OptTtTrinket1SlotGrid; _selectedItemStats = _selectedChar.Items.trinket1.stats;}
            else if (clickedBtn == BtnTrinketSlot){_itemSlot = 12; _gearSlotOffset = 1;  _saveToDbIndex = 14; _clickedImage = OptTrinket2SlotImg; _clickedImgGrid = OptTtTrinket2SlotGrid; _selectedItemStats = _selectedChar.Items.trinket2.stats;}
        }
        /// <summary>
        /// Defines what kind of armor the selected character uses.
        /// </summary>
        private void DefineArmorType()
        {
            switch (_selectedChar.Class)
            {
                case 1:
                case 2:
                case 6:
                    SelectedCharacterArmorType = (int)ClassArmorType.Plate;
                    break;
                case 3:
                case 7:
                    SelectedCharacterArmorType = (int)ClassArmorType.Mail;
                    break;
                case 4:
                case 10:
                case 11:
                case 12:
                    SelectedCharacterArmorType = (int)ClassArmorType.Leather;
                    break;
                case 5:
                case 8:
                case 9:
                    SelectedCharacterArmorType = (int)ClassArmorType.Cloth;
                    break;
            }
        }
        /// <summary>
        /// Handles the SelectedItem event of the ItemList control. called when an item is selected from the ItemList in the ItemContenDialog. it then saved the selected item as a Equipment object, calls a function to alter the Optimized stats, adds the itemid to the corresponding selectedcharacter itemslot, and adds the itemId to the _slotArray.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void ItemList_SelectedItem(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ItemContentDialog.Hide();
                ClearImgGrid(_clickedImgGrid);
                var a = (Equipment)ItemList.SelectedItem;
                if (a == null) return;
                DefineChangeInGearAndStats(a);
                AddItemToSelectedCharacter();
                _slotArray[_saveToDbIndex - 1] = a.Id;
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.Message + "\nThe app was unable to load the selected item. Please try selecting the item again, or try to select a different item.");
                await msg.ShowAsync();
                await LogToDbAsync(ex);
            }
            
        }

        /// <summary>
        /// Clears the img grid.
        /// </summary>
        /// <param name="imgGrid">The img grid.</param>
        private static void ClearImgGrid(Grid imgGrid)
        {
            imgGrid.Children.Clear();
            imgGrid.RowDefinitions.Clear();
        }
        /// <summary>
        /// Defines the change in gear and stats.
        /// </summary>
        /// <param name="a">a.</param>
        private void DefineChangeInGearAndStats(Equipment a)
        {
            ClearImgGrid(_clickedImgGrid);
            _clickedImage.Source = new BitmapImage(new Uri(a.Icon));
            _selectedEquipment = a;
            DefineToolTip(a);
            GetOrgSlotStats();
            RedefineOptStats();
        }

        /// <summary>
        /// Only gets called in a selected character has no item selected in the OptimizedGearslot. sets the imgsource to default img. clears the tooltip and then adds a textblock to the ToolTip. the redefines the Optimized character stats.(this needs to happend if a new character is selectet after a previous character whit optimized gear equipt, to reset the Optimized stats so the dont show the previous characters OptimizedStats)
        /// </summary>
        /// <param name="img">The img.</param>
        /// <param name="grd">The GRD.</param>
        /// <param name="stat">The stat.</param>
        private void DoIfNotOptGearEquipt(Image img, Grid grd, Stat[] stat)
        {
            img.Source = _defaultImg;
            ClearImgGrid(grd);
            var tb = new TextBlock {Text = "Click to add an item"};
            grd.Children.Add(tb);
            _selectedItemStats = stat;
            GetOrgSlotStats();
            CheckIfChangeIsPositive();
        }

        /// <summary>
        /// Checks for existing item equipt by the character. If it finds a item, the Optimized box img for that slot will be set to that items img, the tooltip will be redefined and the Optimized stats will change accordingly, else the DoIfNotOptGearEquipt will be called
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingHeadSlot()
        {
            if (Character.HeadSlot != 0) { DefineItemSlots(BtnHeadSlot); await GetSavedEquipment(Character.HeadSlot); _slotArray[0] = Character.HeadSlot; }
            else { DoIfNotOptGearEquipt(OptHeadSlotImg, OptTtHeadSlotGrid, _selectedChar.Items.head.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingNeckSlot()
        {
            if (Character.NeckSlot != 0) { DefineItemSlots(BtnNeckSlot); await GetSavedEquipment(Character.NeckSlot); _slotArray[1] = Character.NeckSlot; }
            else { DoIfNotOptGearEquipt(OptNeckSlotImg, OptTtNeckSlotGrid, _selectedChar.Items.neck.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingShoulderSlot()
        {
            if (Character.ShoulderSlot != 0) { DefineItemSlots(BtnShoulderSlot); await GetSavedEquipment(Character.ShoulderSlot); _slotArray[2] = Character.ShoulderSlot; }
            else { DoIfNotOptGearEquipt(OptShoulderSlotImg, OptTtShoulderSlotGrid, _selectedChar.Items.shoulder.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingBackSlot()
        {
            if (Character.BackSlot != 0) { DefineItemSlots(BtnBackSlot); await GetSavedEquipment(Character.BackSlot); _slotArray[3] = Character.BackSlot; }
            else { DoIfNotOptGearEquipt(OptBackSlotImg, OptTtBackSlotGrid, _selectedChar.Items.back.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingChestSlot()
        {
            if (Character.ChestSlot != 0) { DefineItemSlots(BtnChestSlot); await GetSavedEquipment(Character.ChestSlot); _slotArray[4] = Character.ChestSlot; }
            else { DoIfNotOptGearEquipt(OptChestSlotImg, OptTtChestSlotGrid, _selectedChar.Items.chest.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingWristSlot()
        {
            if (Character.WristSlot != 0) { DefineItemSlots(BtnWristSlot); await GetSavedEquipment(Character.WristSlot); _slotArray[8] = Character.WristSlot; }
            else { DoIfNotOptGearEquipt(OptWristSlotImg, OptTtWristSlotGrid, _selectedChar.Items.wrist.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot.
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingRing1Slot()
        {
            if (Character.Ring1Slot != 0) { DefineItemSlots(BtnRing1Slot); await GetSavedEquipment(Character.Ring1Slot); _slotArray[10] = Character.Ring1Slot; }
            else { DoIfNotOptGearEquipt(OptRing1SlotImg, OptTtRing1SlotGrid, _selectedChar.Items.finger1.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingTrinket1Slot()
        {
            if (Character.Trinket1Slot != 0) { DefineItemSlots(BtnTrinket1Slot); await GetSavedEquipment(Character.Trinket1Slot); _slotArray[12] = Character.Trinket1Slot; }
            else { DoIfNotOptGearEquipt(OptTrinket1SlotImg, OptTtTrinket1SlotGrid, _selectedChar.Items.trinket1.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingGloveSlot()
        {
            if (Character.GlovesSlot != 0) { DefineItemSlots(BtnGlovesSlot); await GetSavedEquipment(Character.GlovesSlot); _slotArray[9] = Character.GlovesSlot; }
            else { DoIfNotOptGearEquipt(OptGlovesSlotImg, OptTtGlovesSlotGrid, _selectedChar.Items.hands.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot.
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingBeltSlot()
        {
            if (Character.BeltSlot != 0) { DefineItemSlots(BtnBeltSlot); await GetSavedEquipment(Character.BeltSlot); _slotArray[5] = Character.BeltSlot; }
            else { DoIfNotOptGearEquipt(OptBeltSlotImg, OptTtBeltSlotGrid, _selectedChar.Items.waist.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingLegsSlot()
        {
            if (Character.LegsSlot != 0) { DefineItemSlots(BtnLegsSlot); await GetSavedEquipment(Character.LegsSlot); _slotArray[6] = Character.LegsSlot; }
            else { DoIfNotOptGearEquipt(OptLegsSlotImg, OptTtLegsSlotGrid, _selectedChar.Items.legs.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingFeetSlot()
        {
            if (Character.FeetSlot != 0) { DefineItemSlots(BtnFeetSlot); await GetSavedEquipment(Character.FeetSlot); _slotArray[7] = Character.FeetSlot; }
            else { DoIfNotOptGearEquipt(OptFeetSlotImg, OptTtFeetSlotGrid, _selectedChar.Items.feet.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingRing2Slot()
        {
            if (Character.Ring2Slot != 0) { DefineItemSlots(BtnRing2Slot); await GetSavedEquipment(Character.Ring2Slot); _slotArray[11] = Character.Ring2Slot; }
            else { DoIfNotOptGearEquipt(OptRing2SlotImg, OptTtRing2SlotGrid, _selectedChar.Items.finger2.stats); }
        }

        /// <summary>
        /// Same as CheckForExistHeadSlot
        /// </summary>
        /// <returns></returns>
        private async Task CheckForExistingTrinket2Slot()
        {
            if (Character.Trinket2Slot != 0) { DefineItemSlots(BtnTrinketSlot); await GetSavedEquipment(Character.Trinket2Slot); _slotArray[13] = Character.Trinket2Slot; }
            else { DoIfNotOptGearEquipt(OptTrinket2SlotImg, OptTtTrinket2SlotGrid, _selectedChar.Items.trinket2.stats); }
        }


        /// <summary>
        /// Calls the different CheckForExsistingGearSlot functions
        /// </summary>
        /// <returns></returns>
        private async Task CheckForSavedGear()
        {
            await CheckForExistingHeadSlot();
            await CheckForExistingNeckSlot();
           await CheckForExistingShoulderSlot();
            await CheckForExistingBackSlot();
            await CheckForExistingChestSlot();
            await CheckForExistingWristSlot();
            await CheckForExistingRing1Slot();
            await CheckForExistingTrinket1Slot();
            await CheckForExistingGloveSlot();
            await CheckForExistingBeltSlot();
            await CheckForExistingLegsSlot();
            await CheckForExistingFeetSlot();
            await CheckForExistingRing2Slot();
            await CheckForExistingTrinket2Slot();
        }

        /// <summary>
        /// Gets the Equipment from the Db, if the Equipment id == the parameter id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private async Task GetSavedEquipment(int id)
        {
            Equipment = new List<Equipment>(await DataSource.Equipments.Instance.GetEquipment());
            foreach (var c in Equipment)
            {
                if (c.Id == id)
                {
                    DefineChangeInGearAndStats(c);
                }
            }
        }
        /// <summary>
        /// Redefines the opttimized stats.
        /// </summary>
        private void RedefineOptStats()
        {
            if (IsEquipt(_selectedEquipment.Id)) return;
            OptimizedMainStatBox.Text = (int.Parse(OptimizedMainStatBox.Text) + (_selectedEquipment.MainStat - _orgMainStatValue)).ToString();
            OptimizedStaminaBox.Text = (int.Parse(OptimizedStaminaBox.Text) + (_selectedEquipment.Stamina - _orgStaminaValue)).ToString();
            OptimizedHpBox.Text = (int.Parse(OptimizedStaminaBox.Text) * 60).ToString();
            OptimizedMasteryBox.Text = (int.Parse(OptimizedMasteryBox.Text) + (_selectedEquipment.Mastery - _orgMasteryValue)).ToString();
            OptimizedCritBox.Text = (int.Parse(OptimizedCritBox.Text) + (_selectedEquipment.Crit - _orgCritValue)).ToString();
            OptimizedHasteBox.Text = (int.Parse(OptimizedHasteBox.Text) + (_selectedEquipment.Haste - _orgHasteValue)).ToString();
            OptimizedVersatilityBox.Text = (int.Parse(OptimizedVersatilityBox.Text) + (_selectedEquipment.Versatility - _orgVersatilityValue)).ToString();
            CheckIfChangeIsPositive();

        }

        /// <summary>
        /// Determines whether the specified Equipment Allready is Equipt.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <c>true</c> if the specified identifier is equipt; otherwise, <c>false</c>.
        /// </returns>
        private bool IsEquipt(int id)
        {
            foreach (var t in _slotArray)
            {
                if (id == t)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if change is positive. if it is the statValue turns green, if negative it turns red, if it is equal to the Original stat value it turns/stays black
        /// </summary>
        private void CheckIfChangeIsPositive()
        {
            //Mainstat
            if(int.Parse(OptimizedMainStatBox.Text) > int.Parse(OriginalMainStat.Text)){OptimizedMainStatBox.Foreground = new SolidColorBrush(Colors.Green);}
            else if(int.Parse(OptimizedMainStatBox.Text) < int.Parse(OriginalMainStat.Text)) {OptimizedMainStatBox.Foreground = new SolidColorBrush(Colors.Red);}
            else if(int.Parse(OptimizedMainStatBox.Text) == int.Parse(OriginalMainStat.Text)){ OptimizedMainStatBox.Foreground = new SolidColorBrush(Colors.Black);}
            //Stamina and Healthpoints
            if (int.Parse(OptimizedStaminaBox.Text) > int.Parse(OriginalStamina.Text)){ OptimizedStaminaBox.Foreground = new SolidColorBrush(Colors.Green); OptimizedHpBox.Foreground = new SolidColorBrush(Colors.Green);}
            else if(int.Parse(OptimizedStaminaBox.Text) < int.Parse(OriginalStamina.Text)){ OptimizedStaminaBox.Foreground = new SolidColorBrush(Colors.Red); OptimizedHpBox.Foreground = new SolidColorBrush(Colors.Red);}
            else if (int.Parse(OptimizedStaminaBox.Text) == int.Parse(OriginalStamina.Text)){ OptimizedStaminaBox.Foreground = new SolidColorBrush(Colors.Black); OptimizedHpBox.Foreground = new SolidColorBrush(Colors.Black); }
            //Mastery
            if (int.Parse(OptimizedMasteryBox.Text) > int.Parse(OriginalMastery.Text)){ OptimizedMasteryBox.Foreground = new SolidColorBrush(Colors.Green);}
            else if (int.Parse(OptimizedMasteryBox.Text) < int.Parse(OriginalMastery.Text)){ OptimizedMasteryBox.Foreground = new SolidColorBrush(Colors.Red);}
            else if (int.Parse(OptimizedMasteryBox.Text) == int.Parse(OriginalMastery.Text)){OptimizedMasteryBox.Foreground = new SolidColorBrush(Colors.Black);}
            //Critical Strike
            if (int.Parse(OptimizedCritBox.Text) > int.Parse(OriginalCrit.Text)) { OptimizedCritBox.Foreground = new SolidColorBrush(Colors.Green);}
            else if (int.Parse(OptimizedCritBox.Text) > int.Parse(OriginalCrit.Text)) { OptimizedCritBox.Foreground = new SolidColorBrush(Colors.Red);}
            else if (int.Parse(OptimizedCritBox.Text) == int.Parse(OriginalCrit.Text)) { OptimizedCritBox.Foreground = new SolidColorBrush(Colors.Black); }
            //Haste
            if (int.Parse(OptimizedHasteBox.Text) > int.Parse(OriginalHaste.Text)) { OptimizedHasteBox.Foreground = new SolidColorBrush(Colors.Green); }
            else if (int.Parse(OptimizedHasteBox.Text) > int.Parse(OriginalHaste.Text)) { OptimizedHasteBox.Foreground = new SolidColorBrush(Colors.Red); }
            else if (int.Parse(OptimizedHasteBox.Text) == int.Parse(OriginalHaste.Text)) { OptimizedHasteBox.Foreground = new SolidColorBrush(Colors.Black); }
            //Versatility
            if (int.Parse(OptimizedVersatilityBox.Text) > int.Parse(OriginalVersatility.Text)) { OptimizedVersatilityBox.Foreground = new SolidColorBrush(Colors.Green); }
            else if (int.Parse(OptimizedVersatilityBox.Text) > int.Parse(OriginalVersatility.Text)) { OptimizedVersatilityBox.Foreground = new SolidColorBrush(Colors.Red); }
            else if (int.Parse(OptimizedVersatilityBox.Text) == int.Parse(OriginalVersatility.Text)) { OptimizedVersatilityBox.Foreground = new SolidColorBrush(Colors.Black); }
            ClearStats();
        }

        /// <summary>
        /// Clears the stats.
        /// </summary>
        private void ClearStats()
        {
            _orgMainStatValue = 0;
            _orgStaminaValue = 0;
            _orgMasteryValue = 0;
            _orgCritValue = 0;
            _orgHasteValue = 0;
            _orgVersatilityValue = 0;
            
        }
    
        /// <summary>
        /// adds the item id of the selected item, to the selected character(SavedCharacter, so that the saved character can be updatet with the Item id.)
        /// </summary>
        private void AddItemToSelectedCharacter()
        {   
            switch (_itemSlot+ _gearSlotOffset)
            {
                case 1: Character.HeadSlot = _selectedEquipment.Id; break;
                case 2: Character.NeckSlot = _selectedEquipment.Id; break;
                case 3: Character.ShoulderSlot = _selectedEquipment.Id; break;
                case 16: Character.BackSlot = _selectedEquipment.Id; break;
                case 5: Character.ChestSlot = _selectedEquipment.Id; break;
                case 6: Character.BeltSlot = _selectedEquipment.Id; break;
                case 7: Character.LegsSlot = _selectedEquipment.Id; break;
                case 8: Character.FeetSlot = _selectedEquipment.Id; break;
                case 9: Character.WristSlot = _selectedEquipment.Id; break;
                case 10: Character.GlovesSlot = _selectedEquipment.Id; break;
                case 11: Character.Ring1Slot = _selectedEquipment.Id; break;
                case 14: Character.Ring2Slot = _selectedEquipment.Id; break;
                case 12: Character.Trinket1Slot = _selectedEquipment.Id; break;
                case 13: Character.Trinket2Slot = _selectedEquipment.Id; break;
            }
        }

        /// <summary>
        /// Gets the originalslot stats.
        /// </summary>
        private void GetOrgSlotStats()
        {
            foreach (var a in _selectedItemStats)
            {
                switch (a.stat)
                {
                    case 74:
                    case 73:
                    case 71:
                    case 3:
                    case 4:
                    case 5:
                        _orgMainStatValue = a.amount;
                        break;
                    case 40:
                        _orgVersatilityValue = a.amount;
                        break;
                    case 49:
                        _orgMasteryValue = a.amount;
                        break;
                    case 7:
                        _orgStaminaValue = a.amount;
                        break;
                    case 32:
                        _orgCritValue = a.amount;
                        break;
                    case 36:
                        _orgHasteValue = a.amount;
                        break;
                }
            }
        }
        /// <summary>
        /// Defines the tooltip based on the equipments stats.
        /// </summary>
        /// <param name="equipment">The equipment.</param>
        private void DefineToolTip(Equipment equipment)
        {
            var rowOffsett = 0;
            var rowHeight = 15;
            for (var i = 0; i < 10; i++)
            {
                var g = new Grid();
                var tb = new TextBlock();
                switch (i)
                {
                    case 0: tb.Text = equipment.Name; break;
                    case 1: tb.Text = equipment.ConvertedIlvl; break;
                    case 2: if (equipment.Armor != 0){tb.Text = equipment.ConvertedArmor;}else{rowOffsett++; continue;} break;
                    case 3: if (equipment.MainStat != 0){tb.Text = equipment.MainStat + " " + MainStatName;}else{rowOffsett++; continue;} break;
                    case 4: if (equipment.Stamina != 0){tb.Text = equipment.Stamina + " Stamina";}else{rowOffsett++;continue;} break;
                    case 5: if (equipment.Mastery != 0){tb.Text = equipment.Mastery + " Mastery";}else{rowOffsett++;continue;} break;
                    case 6: if (equipment.Crit != 0){tb.Text = equipment.Crit + " Critical Strike";}else{rowOffsett++;continue;} break;
                    case 7: if (equipment.Haste != 0){tb.Text = equipment.Haste + " Haste";}else{rowOffsett++;continue;} break;
                    case 8: if (equipment.Versatility != 0){tb.Text = equipment.Versatility + " Versatility"; }else{rowOffsett++;continue;} break;
                    case 9: if (equipment.EquipmentEffect != null) { rowHeight = 135; tb.Width = 300; tb.Text = equipment.EquipmentEffect;
                            tb.TextWrapping = TextWrapping.Wrap; var colDef = new ColumnDefinition {Width = new GridLength(1, GridUnitType.Auto)};
                            g.ColumnDefinitions.Add(colDef); g.Height = 500; g.Width = 400;}
                        else{rowOffsett++;continue;} break;
                }
                AddToGrid(g, tb, _clickedImgGrid, i-rowOffsett, rowHeight);
            }
            
        }

        /// <summary>
        /// Updates the character to database.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        public async void UpdateCharacterToDb(object sender, RoutedEventArgs e)
        {
            try
            {
                var view = await UpdateCharacterContentDialog.ShowAsync();
                if (view != ContentDialogResult.Primary) return;
                Character.SavedAs = NewCharacterNameBox.Text;
                await DataSource.SavedCharacters.Instance.PutSavedCharacter(Character);
                
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.Message + "\nAttention!\nThe program was unable to save the selected changes.\nClose the program will lead to a loss of all unsaved changes.\nPlease try to save the character a second time.\nYoo can safely select another character without losing your current data");
                await msg.ShowAsync();
                await LogToDbAsync(ex);
            }
            
        }
        /// <summary>
        /// Adds the new character to database.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        public async void AddNewCharacterToDb(object sender, RoutedEventArgs e)
        {   
            var view = await AddNewCharacterContentDialog.ShowAsync();
            if (view != ContentDialogResult.Primary) return;
            CharacterName = AddCharNameBox.Text;
            CharacterServer = AddCharServerBox.Text;
            try
            {
                var url = "https://eu.api.battle.net/wow/character/" + CharacterServer + "/" + CharacterName + "?fields=items&locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye";
                var http = new HttpClient();
                var response = await http.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GameCharacter>(result);
                var classIndex = data.Class;

                var character = new SavedCharacter()
                {
                    Name = data.Name,
                    Level = data.Level,
                    ClassName = _classes[classIndex - 1],
                    Realm = data.Realm,

                };
                await DataSource.SavedCharacters.Instance.AddSavedCharacter(character);
                ViewModel.SavedCharacters.Add(character);
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.Message + "Attention!\nThe character you entered was not added to the program.\nPlease make sure the server and character name is spelled correctly, and that the character exists on the selected server.");
                await msg.ShowAsync();
                await LogToDbAsync(ex);
            }
        }

        /// <summary>
        /// Sets the overlay status.
        /// </summary>
        /// <param name="active">if set to <c>true</c> [active].</param>
        private void SetOverlayStatus(bool active)
        {   
            if (active == false)
            {   
                Overlay.Visibility = Visibility.Collapsed;
                ProgressRing.IsActive = false;
                ProgressRing.Visibility = Visibility.Collapsed;
            }
            else
            {
                Overlay.Visibility = Visibility.Visible;
                ProgressRing.IsActive = true;
                ProgressRing.Visibility = Visibility.Visible;
            }
        }
    }
}
