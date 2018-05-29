using System;
using System.Net.Http;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using ClassLibrary1;
using Newtonsoft.Json;



namespace BlizzStatistics.App.Views
{
    public sealed partial class MythicView
    {
        /// <summary>
        /// The child grid
        /// </summary>
        private Grid _childGrid;
        /// <summary>
        /// The connection
        /// </summary>
        private string _connection;
        /// <summary>
        /// The realm index
        /// </summary>
        private int _realmIndex = 509;
        private int _preRealmIndex = 509;
        /// <summary>
        /// The dungeon index
        /// </summary>
        private int _dungeonIndex = 197;

        /// <summary>
        /// Initializes a new instance of the <see cref="MythicView"/> class.
        /// </summary>
        public MythicView()
        {
            InitializeComponent();
            GetData();
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        private async void GetData()
        {
            try
            {
                _connection = "https://eu.api.battle.net/data/wow/connected-realm/" + _realmIndex + "/mythic-leaderboard/" + _dungeonIndex + "/period/645?namespace=dynamic-eu&locale=en_GB&access_token=fb5hv9pjubvebavu85qxstjz";
                var ur = new Uri(_connection);
                var client = new HttpClient();
                var response = await client.GetStringAsync(ur);
                var data = JsonConvert.DeserializeObject<MythicRootobject>(response);
                AddToColumns(data);
                ConvertTimeStampToTime(data.leading_groups[0].Duration, TbBestTime);
                TbAff1.Text = data.keystone_affixes[0].keystone_affix.Name;
                TbAff2.Text = data.keystone_affixes[1].keystone_affix.Name;
                TbAff3.Text = data.keystone_affixes[2].keystone_affix.Name;
            }
            catch (Exception e)
            {
                ////ADD windu med feilmelding ang roleback
                Console.WriteLine(e);
                _realmIndex = _preRealmIndex;
                GetData();
            }
        }

        private void ConvertTimeStampToTime(long time, TextBlock tb)
        {
            time = time / 1000;
            var timeHour = DateTimeOffset.FromUnixTimeSeconds(time).DateTime.Hour;
            var timeMin = DateTimeOffset.FromUnixTimeSeconds(time).DateTime.Minute;
            var timeSec = DateTimeOffset.FromUnixTimeSeconds(time).DateTime.Second;
            
            tb.Text = timeHour +":"+ timeMin + ":" + timeSec;
        }
        private void ConvertTimeStampToDate(long time, TextBlock tb)
        {
            var timeHour = DateTimeOffset.FromUnixTimeMilliseconds(time).Day + "/" +DateTimeOffset.FromUnixTimeMilliseconds(time).Month + "/" + DateTimeOffset.FromUnixTimeMilliseconds(time).Year;
            

            tb.Text = timeHour;
        }

        /// <summary>
        /// Defines the text.
        /// </summary>
        /// <param name="tb">The tb.</param>
        private static void DefineText(TextBlock tb)
        {
           
            tb.TextAlignment = TextAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.FontSize = 15;
            tb.Foreground = new SolidColorBrush(Colors.Black);
            tb.FontStretch = FontStretch.ExtraCondensed;
        }

        /// <summary>
        /// Adds to columns.
        /// </summary>
        /// <param name="data">The data.</param>
        private void AddToColumns(MythicRootobject data)
        {
            var mainGrid = MenuGrid;
            _childGrid = mainGrid;
            RelativePanel.SetAlignLeftWithPanel(MainMythicPanel, true);
            RelativePanel.SetAlignRightWithPanel(MainMythicPanel, true);
           
            for (var i = 0; i < CheckNumberOfLeadingGroups(data); i++)
            {
                for (var a = 0; a < 9; a++)
                {
                    var tb = new TextBlock();
                    DefineText(tb);
                    switch (a)
                    {
                        case 0:
                            tb.Text = data.leading_groups[i].Ranking.ToString();
                            break;
                        case 1:
                            tb.Text = data.leading_groups[i].keystone_level.ToString();                        
                            break;
                        case 2:
                            ConvertTimeStampToTime(data.leading_groups[i].Duration, tb);                            
                            break;
                        case 3:
                            AddGroupMember(data, mainGrid, a, i);
                            a = 7;
                            break;
                        case 8:
                            ConvertTimeStampToDate(data.leading_groups[i].completed_timestamp, tb);                           
                            break;
                    }
                    if (a == 7) continue;
                    var g = new Grid();
                    AddtoGrid(g, mainGrid, tb, a, i);
                }
            }
        }

        private static int CheckNumberOfLeadingGroups(MythicRootobject data)
        {
            
           return data.leading_groups.Length > 100 ? 100 : data.leading_groups.Length-1;
        }
        /// <summary>
        /// Addtoes the grid.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="mainGrid">The main grid.</param>
        /// <param name="tb">The tb.</param>
        /// <param name="a">a.</param>
        /// <param name="i">The i.</param>
        private static void AddtoGrid(Grid g, Grid mainGrid, UIElement tb, int a, int i)
        {
            var view = new Viewbox{ Height = 40, Child = tb};
            g.Children.Add(view);
            // Here you set the Grid properties, such as border and alignment
            g.BorderThickness = new Thickness(0, 2, 0, 2);
            g.BorderBrush = new SolidColorBrush(Colors.Black);
            g.HorizontalAlignment = HorizontalAlignment.Stretch;
            g.VerticalAlignment = VerticalAlignment.Stretch;
            CheckColor(g,i);
            // Add the newly created Grid to the outer Grid
            var rowHeight = new RowDefinition{ Height = new GridLength(0.1,GridUnitType.Auto) };
            mainGrid.RowDefinitions.Add(rowHeight);
            Grid.SetRow(g, i+2);
            Grid.SetColumn(g, a);
            mainGrid.Children.Add(g);
        }

        private static void CheckColor(Grid g, int i)
        {
            g.Background = i % 2 != 0 ? new SolidColorBrush(Colors.SaddleBrown) : new SolidColorBrush(Colors.SandyBrown);
        }
        /// <summary>
        /// Adds the group member.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="mainGrid">The main grid.</param>
        /// <param name="a">a.</param>
        /// <param name="i">The i.</param>
        private static void AddGroupMember(MythicRootobject data, Grid mainGrid, int a, int i)
        {
            var columnCount = a;
            foreach (var t in data.leading_groups[i].Members)
            {
                var g = new Grid();
                var tb = new TextBlock();
                DefineText(tb);
                tb.Text = t.Profile.Name;
                AddtoGrid(g, mainGrid, tb, columnCount, i);
                columnCount++;
            }
        }

        /// <summary>
        /// Handles the OnSelectionChanged event of the cbServer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void CbServer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var realm = CbServer.SelectedItem as Realm;
            _preRealmIndex = _realmIndex;
            if (realm != null) _realmIndex = realm.id;
            DestroyGrid();
        }

        /// <summary>
        /// Handles the OnSelectionChanged event of the cbDungeon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void CbDungeon_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbDungeon.SelectedItem)
            {
                case "Black Rook Hold":
                    _dungeonIndex = 199;
                    break;
                case "Darkheart Thicket":
                    _dungeonIndex = 198;
                    break;
                case "Eye of Azshara":
                    _dungeonIndex = 197;
                    break;
                case "Halls of Valor":
                    _dungeonIndex = 200;
                    break;
                case "Neltharion's Lair":
                    _dungeonIndex = 206;
                    break;
                case "Vault of the Wardens":
                    _dungeonIndex = 207;
                    break;
                case "Maw of Souls":
                    _dungeonIndex = 208;
                    break;
                case "The Arcway":
                    _dungeonIndex = 209;
                    break;
                case "Court of Stars":
                    _dungeonIndex = 210;
                    break;
                case "Lower Karazhan":
                    _dungeonIndex = 227;
                    break;
                case "Upper Karazhan":
                    _dungeonIndex = 234;
                    break;
                case "Cathedral of Eternal Night":
                    _dungeonIndex = 233;
                    break;
                case "Seat of the Triumvirate":
                    _dungeonIndex = 239;
                    break;
            }
            DestroyGrid();
        }
        /// <summary>
        /// Destroys the grid.
        /// </summary>
        private void DestroyGrid()
        {
            for (var i = _childGrid.Children.Count-1; i > 12; i--)
            {
                _childGrid.Children.RemoveAt(i);
            }
            GetData();
        }
    }
    

}
