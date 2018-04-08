using System;
using System.Net.Http;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using ClassLibrary1;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlizzStatistics.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PvpPage
    {

        private string _classColor;
        private string _playerClass;
        private int _initNumber = 10;
        private Grid _childGrid;
        private int _factionIndex = 2;
        private int _tempInitNumber;
        private int _sortClassIndex = 13;
        private string _playerRace = "Error";
        private int _selectedLadder = 1;
        
        

        public PvpPage()
        {
            InitializeComponent();
           GetData();
        }

        private void GetData()
        {
            if (_selectedLadder == 3)
            {
                GetRbg();
            } else if (_selectedLadder == 2)
            {
                GetThrees();
            }
            else
            {
                GetTwos();
            }    
        }

        private async void GetTwos()
        {
            try
            {
                const string url = "https://eu.api.battle.net/wow/leaderboard/2v2?locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye";
                var client = new HttpClient();
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<Rootobject>(response);
                CreateGrid(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                GetData();
            }
        }

        private async void GetThrees()
        {
            try
            {
                const string url = "https://eu.api.battle.net/wow/leaderboard/3v3?locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye";
                var client = new HttpClient();
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<Rootobject>(response);
                CreateGrid(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                GetData();
            }
        }

        private async void GetRbg()
        {
            try
            {
                const string url = "https://eu.api.battle.net/wow/leaderboard/rbg?locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye";
                var client = new HttpClient();
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<Rootobject>(response);
                CreateGrid(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                GetData();
            }
        }

        private void CreateGrid(Rootobject data)
        {
            Grid mainGrid = new Grid();
            _childGrid = mainGrid;
            Root.Children.Add(mainGrid);
            int rowCount = 0;
            _tempInitNumber = _initNumber;
            for (int i = 0; i < _tempInitNumber; i++)
            {
                if (_factionIndex == 2 && _sortClassIndex == 13)
                {
                    AddToColumns(i, data, mainGrid, rowCount);
                    rowCount++;
                }
                else if (data.Rows[i].FactionId == _factionIndex && data.Rows[i].ClassId == _sortClassIndex || data.Rows[i].FactionId == _factionIndex && _sortClassIndex == 13 || _factionIndex == 2 && data.Rows[i].ClassId == _sortClassIndex)
                {
                    AddToColumns(i, data, mainGrid, rowCount);
                    rowCount++;
                }
                else
                {
                    _tempInitNumber++;
                }
            }
        }

        private void AddToColumns(int i, Rootobject data, Grid mainGrid, int rowCount)
        {
            _classColor = data.Rows[i].ClassId.ToString();
            CheckClass(_classColor);
            for (int a = 0; a < 9; a++)
            {
                TextBlock tb = new TextBlock();
                tb.FontSize = 12;
                tb.TextAlignment = TextAlignment.Center;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.FontSize = 20;
                tb.Foreground = new SolidColorBrush(Colors.Black);
                Grid g = new Grid();
                switch (a)
                {
                    case 0: tb.Text = data.Rows[i].Ranking.ToString();
                        break;
                    case 1:
                        tb.Text = data.Rows[i].Name;
                        break;
                    case 2:
                        if (data.Rows[i].FactionId == 1)
                        {
                            tb.Text = "Horde";
                        }
                        else
                        {
                            tb.Text = "Alliance";
                        }
                        
                        break;
                    case 3:
                        CheckClass(data.Rows[i].ClassId.ToString());
                        tb.Text = _playerClass;
                        break;
                    case 4:
                        tb.Text = data.Rows[i].RealmName;
                        break;
                    case 5:
                        tb.Text = data.Rows[i].Rating.ToString();
                        break;
                    case 6:
                        tb.Text = data.Rows[i].SeasonWins.ToString();
                        break;
                    case 7:
                        tb.Text = data.Rows[i].SeasonLosses.ToString();
                        break;
                    case 8:
                        CheckRace(data.Rows[i].RaceId);
                        tb.Text = _playerRace;
                        break;
                }
                
                g.Children.Add(tb);

                var color = GetSolidColorBrush(_classColor).Color;
                SolidColorBrush brush = new SolidColorBrush(color);

                // Here you set the Grid properties, such as border and alignment
                // You can add other properties and events you need
                g.BorderThickness = new Thickness(1, 2, 1, 2);
                g.BorderBrush = new SolidColorBrush(Colors.Black);
                g.HorizontalAlignment = HorizontalAlignment.Stretch;
                g.VerticalAlignment = VerticalAlignment.Stretch;

                g.Background = brush;

                // Add the newly created Grid to the outer Grid
                
                RowDefinition rowHeight = new RowDefinition();
                rowHeight.Height = new GridLength(50);
                mainGrid.RowDefinitions.Add(rowHeight);
                ColumnDefinition colWidth = new ColumnDefinition();
                colWidth.Width = new GridLength(166);
                mainGrid.ColumnDefinitions.Add(colWidth);

                Grid.SetRow(g, rowCount);
                Grid.SetColumn(g, a);
                mainGrid.Children.Add(g);
                
            }
            
        }

        private void CheckClass(string c)
        {
            switch (c)
            {
                case "1" : _classColor = "#FFC79C6E";
                    _playerClass = "Warrior";
                    break;
                case "2":
                    _classColor = "#FFF58CBA";
                    _playerClass = "Paladin";
                    break;
                case "3":
                    _classColor = "#FFABD473";
                    _playerClass = "Hunter";
                    break;
                case "4":
                    _classColor = "#FFFFF569";
                    _playerClass = "Rogue";
                    break;
                case "5":
                    _classColor = "#FFFFFFFF";
                    _playerClass = "Priest";
                    break;
                case "6":
                    _classColor = "#FFC41F3B";
                    _playerClass = "Death Knight";
                    break;
                case "7":
                    _classColor = "#FF0070DE";
                    _playerClass = "Shaman";
                    break;
                case "8":
                    _classColor = "#FF69CCF0";
                    _playerClass = "Mage";
                    break;
                case "9":
                    _classColor = "#FF9482C9";
                    _playerClass = "Warlock";
                    break;
                case "10":
                    _classColor = "#FF00FF96";
                    _playerClass = "Monk";
                    break;
                case "11":
                    _classColor = "#FFFF7D0A";
                    _playerClass = "Druid";
                    break;
                case "12":
                    _classColor = "#FFA330C9";
                    _playerClass = "Demon Hunter";
                    break;
            }              
        }

        public SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(a, r, g, b));
            return myBrush;
        }

        private void CbSelNumber_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbSelNumber.SelectedItem)
            {
                case "Top 10": _initNumber = 10;
                    break;
                case "Top 25":
                    _initNumber = 25;
                    break;
                case "Top 50":
                    _initNumber = 50;
                    break;
                case "Top 100":
                    _initNumber = 100;
                    break;
            }

            DestroyGrid();
        }

        private void CbFaction_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbFaction.SelectedItem)
            {
                case "Horde":
                    _factionIndex = 1;
                    break;
                case "Alliance":
                    _factionIndex = 0;
                    break;
                case "All Factions":
                    _factionIndex = 2;
                    break;
            }

            DestroyGrid();
        }

        private void CbClasses_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbClasses.SelectedItem)
            {
                case "Warrior":
                    _sortClassIndex = 1;
                    break;
                case "Paladin":
                    _sortClassIndex = 2;
                    break;
                case "Hunter":
                    _sortClassIndex = 3;
                    break;
                case "Rogue":
                    _sortClassIndex = 4;
                    break;
                case "Priest":
                    _sortClassIndex = 5;
                    break;
                case "Death Knight":
                    _sortClassIndex = 6;
                    break;
                case "Shaman":
                    _sortClassIndex = 7;
                    break;
                case "Mage":
                    _sortClassIndex = 8;
                    break;
                case "Warlock":
                    _sortClassIndex = 9;
                    break;
                case "Monk":
                    _sortClassIndex = 10;
                    break;
                case "Druid":
                    _sortClassIndex = 11;
                    break;
                case "Demon Hunter":
                    _sortClassIndex = 12;
                    break;
                case "All Classes":
                    _sortClassIndex = 13;
                    break;
            }
            DestroyGrid();
        }

        private void CheckRace(int raceIndex)
        {
            switch (raceIndex)
            {
                case 1: _playerRace = "Human";
                    break;
                case 2:
                    _playerRace = "Orc";
                    break;
                case 3:
                    _playerRace = "Dwarf";
                    break;
                case 4:
                    _playerRace = "Night Elf";
                    break;
                case 5:
                    _playerRace = "Undead";
                    break;
                case 6:
                    _playerRace = "Tauren";
                    break;
                case 7:
                    _playerRace = "Gnome";
                    break;
                case 8:
                    _playerRace = "Troll";
                    break;
                case 9:
                    _playerRace = "Goblin";
                    break;
                case 10:
                    _playerRace = "Blood Elf";
                    break;
                case 11:
                    _playerRace = "Draenei";
                    break;
                case 22:
                    _playerRace = "Worgen";
                    break;
                case 24:
                    _playerRace = "Pandaren";
                    break;
                case 25:
                    _playerRace = "Pandaren";
                    break;
                case 26:
                    _playerRace = "Pandaren";
                    break;
                case 27:
                    _playerRace = "Nightborne";
                    break;
                case 28:
                    _playerRace = "Highmauntain Tauren";
                    break;
                case 29:
                    _playerRace = "Void Elf";
                    break;
                case 30:
                    _playerRace = "Lightforged Draenei";
                    break;
            }

            
        }


        private void CbLadder_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbLadder.SelectedItem)
            {
                case "2v2 Ladder":
                    _selectedLadder = 1;
                    break;
                case "3v3 Ladder":
                    _selectedLadder = 2;
                    break;
                case "Rbg Ladder":
                    _selectedLadder = 3;
                    break;
            }
            DestroyGrid();
        }

        private void DestroyGrid()
        {
            Root.Children.Remove(_childGrid);
            GetData();
        }
    }
}
