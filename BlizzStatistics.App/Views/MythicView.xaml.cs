using System;
using System.Net.Http;
using Windows.UI;
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
        private string _connection = "https://eu.api.battle.net/data/wow/connected-realm/509/mythic-leaderboard/197/period/641?namespace=dynamic-eu&locale=en_GB&access_token=ugnefz3dkked237rzcd5nnav";
        /// <summary>
        /// The realm index
        /// </summary>
        private string _realmIndex = "509";
        /// <summary>
        /// The dungeon index
        /// </summary>
        private string _dungeonIndex = "199";

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
                var ur = new Uri(_connection);
                var client = new HttpClient();
                var response = await client.GetStringAsync(ur);
                var data = JsonConvert.DeserializeObject<MythicRootobject>(response);
                AddToColumns(data);
                TbBestTime.Text = data.leading_groups[0].Duration.ToString();
                TbAff1.Text = data.keystone_affixes[0].keystone_affix.Name;
                TbAff2.Text = data.keystone_affixes[1].keystone_affix.Name;
                TbAff3.Text = data.keystone_affixes[2].keystone_affix.Name;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                GetData();
            }
        }

        /// <summary>
        /// Defines the text.
        /// </summary>
        /// <param name="tb">The tb.</param>
        private static void DefineText(TextBlock tb)
        {
            tb.FontSize = 12;
            tb.TextAlignment = TextAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.FontSize = 20;
            tb.Foreground = new SolidColorBrush(Colors.White);
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
           
            for (var i = 0; i < 100; i++)
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
                        case 2: tb.Text = data.leading_groups[i].Duration.ToString();                           
                            break;
                        case 3:
                            AddGroupMember(data, mainGrid, a, i);
                            a = 7;
                            break;
                        case 8:
                            tb.Text = data.leading_groups[i].completed_timestamp.ToString();                           
                            break;
                    }
                    if (a == 7) continue;
                    var g = new Grid();
                    AddtoGrid(g, mainGrid, tb, a, i);
                }
            }
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
            g.Children.Add(tb);
            // Here you set the Grid properties, such as border and alignment
            g.BorderThickness = new Thickness(1, 2, 1, 2);
            g.BorderBrush = new SolidColorBrush(Colors.Wheat);
            g.HorizontalAlignment = HorizontalAlignment.Stretch;
            g.VerticalAlignment = VerticalAlignment.Stretch;

            // Add the newly created Grid to the outer Grid
            var rowHeight = new RowDefinition {Height = new GridLength(50)};
            mainGrid.RowDefinitions.Add(rowHeight);
            Grid.SetRow(g, i+2);
            Grid.SetColumn(g, a);
            mainGrid.Children.Add(g);
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
            for (var c = 0; c < 5; c++)
            {
                var g = new Grid();
                var tb = new TextBlock();
                DefineText(tb);
                tb.Text = data.leading_groups[i].Members[c].Profile.Name;
                AddtoGrid(g, mainGrid, tb, columnCount, i);
                columnCount++;
            }
        }

        /// <summary>
        /// Handles the OnSelectionChanged event of the cbServer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbServer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {    
            switch (CbServer.SelectedItem)
            {
                case "Garona":
                    _realmIndex = "509";
                    break;
                case "Vol'jin":
                    _realmIndex = "510";
                    break;
                case "Sunstrider":
                    _realmIndex = "511";
                    break;
            }
            _connection = "https://eu.api.battle.net/data/wow/connected-realm/"+_realmIndex+"/mythic-leaderboard/"+_dungeonIndex+ "/period/641?namespace=dynamic-eu&locale=en_GB&access_token=ugnefz3dkked237rzcd5nnav";
            DestroyGrid();
        }

        /// <summary>
        /// Handles the OnSelectionChanged event of the cbDungeon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbDungeon_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbDungeon.SelectedItem)
            {
                case "Black Rook Hold":
                    _dungeonIndex = "199";
                    break;
                case "Darkheart Thicket":
                    _dungeonIndex = "198";
                    break;
                case "Eye of Azshara":
                    _dungeonIndex = "197";
                    break;
            }
            _connection = "https://eu.api.battle.net/data/wow/connected-realm/" + _realmIndex + "/mythic-leaderboard/" + _dungeonIndex + "/period/641?namespace=dynamic-eu&locale=en_GB&access_token=ugnefz3dkked237rzcd5nnav";
            DestroyGrid();
        }
        /// <summary>
        /// Destroys the grid.
        /// </summary>
        private void DestroyGrid()
        {
            for (var i = _childGrid.Children.Count-13; i > 12; i--)
            {
                _childGrid.Children.RemoveAt(i);
            }
            GetData();
        }
    }
    

}
