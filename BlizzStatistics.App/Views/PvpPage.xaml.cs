using System;
using System.Net.Http;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using ClassLibrary1;
using Newtonsoft.Json;

namespace BlizzStatistics.App.Views
{
    public sealed partial class PvpPage
    {
        private readonly string[] _classColors = { "#FFC79C6E", "#FFF58CBA", "#FFABD473", "#FFFFF569", "#FFFFFFFF", "#FFC41F3B", "#FF0070DE", "#FF69CCF0", "#FF9482C9", "#FF00FF96", "#FFFF7D0A", "#FFA330C9" };
        private readonly string[] _playerClasses = { "Warrior", "Paladin", "Hunter", "Rogue", "Priest", "Death Knight", "Shaman", "Mage", "Warlock", "Monk", "Druid", "Demon Hunter" };
        private readonly string[] _raceArray = { "Human", "Orc", "Dwarf", "Night Elf", "Undead", "Tauren", "Gnome", "Troll", "Goblin", "Blood Elf", "Draenei", "Worgen", "Pandaren", "Nightborne", "Highmauntain Tauren", "Void Elf", "Lightforged Draenei" };
        private string _classColor;
        private string _playerClass;
        private int _initNumber = 50;
        private Grid _childGrid;
        private int _factionIndex = 2;
        private int _tempInitNumber;
        private int _sortClassIndex = 13;
        private string _playerRace = "Error";
        private int _selectedLadder = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="PvpPage"/> class.
        /// </summary>
        public PvpPage()
        {
           InitializeComponent();
           GetData();
        }

        /// <summary>
        /// Selects with ladder to get data from.
        /// </summary>
        private void GetData()
        {
            switch (_selectedLadder)
            {
                case 3: GetLadder("rbg");
                    break;
                case 2: GetLadder("3v3");
                    break;
                default: GetLadder("2v2");
                    break;
            }
        }
       
        /// <summary>
        /// Gets the data from the selected ladder.
        /// </summary>
        /// <param name="ladder">The ladder.</param>
        private async void GetLadder(string ladder)
        {   
            SetOverlayStatus(true);
            try
            {
                using (var client = new HttpClient())
                {
                    var url = "https://eu.api.battle.net/wow/leaderboard/" + ladder + "?locale=en_GB&apikey=b4m972rd82u2pkrwyn3svmt2nngna7ye";
                    var response = await client.GetStringAsync(url);
                    var data = JsonConvert.DeserializeObject<Rootobject>(response);
                    CreateGrid(data);
                }
            }
            catch (Exception e)
            {
                MessageDialog msg = new MessageDialog(e.Message + "\nThe selected Ladder could not be found. Please Select another ladder");
                await msg.ShowAsync();
                await LogToDbAsync(e);
            }
            SetOverlayStatus(false);
        }
       
        // Medthod that logs an exceptions by createing an instance of the ExceptionHandler class and uploads the object to the database.
        private async System.Threading.Tasks.Task LogToDbAsync(Exception e)
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
        /// Selects the players from the RootObject that should be shown in the grid, filtered by rank, faction, class and how many players that should be shown at a given time. this is selected by the user, from the 2nd time it is run.
        /// </summary>
        /// <param name="data">The data.</param>
        private void CreateGrid(Rootobject data)
        {
            var mainGrid = MenuGrid;
            _childGrid = mainGrid;
            var rowCount = 2;
            _tempInitNumber = _initNumber;
            for (var i = 0; i < _tempInitNumber; i++)
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

        /// <summary>
        /// Defines a Textblock
        /// </summary>
        /// <param name="tb">The tb.</param>
        private static void DefineText(TextBlock tb)
        {
            tb.FontSize = 12;
            tb.TextAlignment = TextAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.FontSize = 20;
            tb.Foreground = new SolidColorBrush(Colors.Black);
        }

        /// <summary>
        /// Creates a Textblock and Defines its values by calling the DefineText(). Sets the Textblock.Text and call AddToGrid for each column in 1 row(9). Also gets the class color of the selected Player(RootObject data). Also creates a new temprary Grid g.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="data">The data.</param>
        /// <param name="mainGrid">The main grid.</param>
        /// <param name="rowCount">The row count.</param>
        private void AddToColumns(int i, Rootobject data, Grid mainGrid, int rowCount)
        {
            _classColor = data.Rows[i].ClassId.ToString();
            CheckClass(int.Parse(_classColor));
            for (var a = 0; a < 9; a++)
            {
                var tb = new TextBlock();
                DefineText(tb);
                var g = new Grid();
                switch (a)
                {
                    case 0: tb.Text = data.Rows[i].Ranking.ToString();
                        break;
                    case 1:
                        tb.Text = data.Rows[i].Name;
                        break;
                    case 2:
                        tb.Text = data.Rows[i].FactionId == 1 ? "Horde" : "Alliance";
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

        /// <summary>
        /// Adds the previous created Textblock tb to the grid g, Then creates colorbrush from the player class color. Defines size, alignment and border for g, and sets the g.backgroundcolor to the newly created brush. Defines a new rowdefinition and adds it to the maingrid. Adds the Grid g to the correct row and colum in maingrid. 
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="mainGrid">The main grid.</param>
        /// <param name="tb">The tb.</param>
        /// <param name="a">a.</param>
        /// <param name="rowCount">The row count.</param>
        private void AddtoGrid(Grid g, Grid mainGrid, UIElement tb, int a, int rowCount)
        {
            g.Children.Add(tb);
            var color = GetSolidColorBrush(_classColor).Color;
            var brush = new SolidColorBrush(color);
            g.BorderThickness = new Thickness(0, 2, 0, 2);
            g.BorderBrush = new SolidColorBrush(Colors.Black);
            g.HorizontalAlignment = HorizontalAlignment.Stretch;
            g.VerticalAlignment = VerticalAlignment.Stretch;
            g.Background = brush;
            // Add the newly created Grid to the outer Grid
            var rowHeight = new RowDefinition {Height = new GridLength(5.0,GridUnitType.Star)};
            mainGrid.RowDefinitions.Add(rowHeight);
            Grid.SetRow(g, rowCount);
            Grid.SetColumn(g, a);
            mainGrid.Children.Add(g);
        }

        /// <summary>
        /// Checks the class.
        /// </summary>
        /// <param name="c">The c.</param>
        private void CheckClass(int c)
        {
            _classColor = _classColors[c - 1];
            _playerClass = _playerClasses[c - 1];
        }

        /// <summary>
        /// Gets(Converts) a Hex-string to a solidcolorbrush. 
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns></returns>
        public SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            var a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            var r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            var g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            var b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            var myBrush = new SolidColorBrush(Color.FromArgb(a, r, g, b));
            return myBrush;
        }

        /// <summary>
        /// Handles the OnSelectionChanged event for the number of ranks to view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void CbSelNumber_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbSelNumber.SelectedItem)
            {
                case "Top 50":
                    _initNumber = 50;
                    break;
                case "Top 100":
                    _initNumber = 100;
                    break;
                case "Top 150":
                    _initNumber = 150;
                    break;
                case "Top 200":
                    _initNumber = 200;
                    break;
            }
            DestroyGrid();
        }

        /// <summary>
        /// Sets faction to view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Sets Class to view
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void CbClasses_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for(var i = 0; i<_playerClasses.Length;i++ )
            {
                if (CbClasses.SelectedItem != null && CbClasses.SelectedItem.Equals(_playerClasses[i]))
                {
                    _sortClassIndex = i + 1;
                }else if (CbClasses.SelectedItem != null && CbClasses.SelectedItem.Equals( "All Classes"))
                {
                    _sortClassIndex = 13;
                }
            }
            DestroyGrid();
        }

        /// <summary>
        /// Checks the race.
        /// </summary>
        /// <param name="raceIndex">Index of the race.</param>
        private void CheckRace(int raceIndex)
        {   
            if (raceIndex == 22)
            {
                raceIndex = 12;
            } 
            else if (raceIndex >= 24 && raceIndex <=26)
            {
                raceIndex = 13;
            }
            else if (raceIndex >= 27)
            {
                raceIndex = raceIndex - 13;
            }
            _playerRace = _raceArray[raceIndex - 1];
        }

        /// <summary>
        /// Handles the OnSelectionChanged event of the ladder menu.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void CbLadder_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbLadder.SelectedItem)
            {
                case "2v2":
                    _selectedLadder = 1;
                    break;
                case "3v3":
                    _selectedLadder = 2;
                    break;
                case "Rbg":
                    _selectedLadder = 3;
                    break;
            }
            DestroyGrid();
        }

        /// <summary>
        /// Destroys the grid.
        /// </summary>
        private void DestroyGrid()
        {
            for (var i = _childGrid.Children.Count - 1; i > 17; i--)
            {
                _childGrid.Children.RemoveAt(i);
            }
            GetData();
        }
        //If active = true sets a gray rectangle with 0.8 opacity to be visible. this takes yp the whole screen. Also shows the progressring. this is my attempt at creating a Overlay.
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
