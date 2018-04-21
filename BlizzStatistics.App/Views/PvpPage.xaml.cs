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
        private string[] classColors = { "#FFC79C6E", "#FFF58CBA", "#FFABD473", "#FFFFF569", "#FFFFFFFF", "#FFC41F3B", "#FF0070DE", "#FF69CCF0", "#FF9482C9", "#FF00FF96", "#FFFF7D0A", "#FFA330C9" };
        private string[] playerClasses = { "Warrior", "Paladin", "Hunter", "Rogue", "Priest", "Death Knight", "Shaman", "Mage", "Warlock", "Monk", "Druid", "Demon Hunter" };
        private string[] raceArray = { "Human", "Orc", "Dwarf", "Night Elf", "Undead", "Tauren", "Gnome", "Troll", "Goblin", "Blood Elf", "Draenei", "Worgen", "Pandaren", "Nightborne", "Highmauntain Tauren", "Void Elf", "Lightforged Draenei" };
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
            Grid mainGrid = MenuGrid;
            _childGrid = mainGrid;
            
            int rowCount = 2;
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
        private void DefineText(TextBlock tb)
        {
            tb.FontSize = 12;
            tb.TextAlignment = TextAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.FontSize = 20;
            tb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void AddToColumns(int i, Rootobject data, Grid mainGrid, int rowCount)
        {
            _classColor = data.Rows[i].ClassId.ToString();
            CheckClass(Int32.Parse(_classColor));
            for (int a = 0; a < 9; a++)
            {
                TextBlock tb = new TextBlock();
                DefineText(tb);
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
                        CheckClass(data.Rows[i].ClassId);
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
                
               AddtoGrid(g, mainGrid, tb, a, rowCount);
                
            }
            
        }
        private void AddtoGrid(Grid g, Grid mainGrid, TextBlock tb, int a, int rowCount)
        {
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


            Grid.SetRow(g, rowCount);
            Grid.SetColumn(g, a);
            mainGrid.Children.Add(g);
        }

        private void CheckClass(int c)
        {
            _classColor = classColors[c - 1];
            _playerClass = playerClasses[c - 1];
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
            for(int i = 0; i<playerClasses.Length;i++ )
            {
                if (CbClasses.SelectedItem != null && CbClasses.SelectedItem.Equals(playerClasses[i]))
                {
                    _sortClassIndex = i + 1;
                }else if (CbClasses.SelectedItem != null && CbClasses.SelectedItem.Equals( "All Classes"))
                {
                    _sortClassIndex = 13;
                }
            }
            DestroyGrid();
        }

        private void CheckRace(int raceIndex)
        {   
            
            if (raceIndex == 22)
            {
                raceIndex = 12;
            } else if (raceIndex >= 24 && raceIndex <=26)
            {
                raceIndex = 13;
            }else if (raceIndex >= 27)
            {
                raceIndex = raceIndex - 13;
            }
            _playerRace = raceArray[raceIndex - 1];
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
            for (int i = _childGrid.Children.Count - 18; i > 17; i--)
            {
                _childGrid.Children.RemoveAt(i);
            }
            GetData();
        }
    }
}
