using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
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
    public sealed partial class MythicView : Page
    {
        int[] realmLinks;
        private Grid _childGrid;
        private string connection = "https://eu.api.battle.net/data/wow/connected-realm/509/mythic-leaderboard/197/period/641?namespace=dynamic-eu&locale=en_GB&access_token=ugnefz3dkked237rzcd5nnav";
        private string realmIndex = "509";
        private string dungeonIndex = "199";

        public MythicView()
        {
            this.InitializeComponent();
            
            GetData();
        }

        private async void GetData()
        {
            
            try
            {
                Uri ur = new Uri(connection);
                var client = new HttpClient();
                var response = await client.GetStringAsync(ur);
                var data = JsonConvert.DeserializeObject<MythicRootobject>(response);
                AddToColumns(data);
                tbBestTime.Text = data.leading_groups[0].duration.ToString();
                TbAff1.Text = data.keystone_affixes[0].keystone_affix.name;
                TbAff2.Text = data.keystone_affixes[1].keystone_affix.name;
                TbAff3.Text = data.keystone_affixes[2].keystone_affix.name;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                GetData();
            }
        }
        
        private void DefineText(TextBlock tb)
        {
            tb.FontSize = 12;
            tb.TextAlignment = TextAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.FontSize = 20;
            tb.Foreground = new SolidColorBrush(Colors.White);
        }

        private void AddToColumns(MythicRootobject data)
        {
            Grid mainGrid = MenuGrid;
            _childGrid = mainGrid;
            RelativePanel.SetAlignLeftWithPanel(MainMythicPanel, true);
            RelativePanel.SetAlignRightWithPanel(MainMythicPanel, true);
            
            //MythicRoot.Children.Add(mainGrid);
            for (int i = 0; i < 100; i++)
            {
                for (int a = 0; a < 9; a++)
                {
                    TextBlock tb = new TextBlock();
                    DefineText(tb);

                    ColumnDefinition colWidth = new ColumnDefinition();
                    switch (a)
                    {
                        case 0:
                            tb.Text = data.leading_groups[i].ranking.ToString();
                            break;
                        case 1:
                            tb.Text = data.leading_groups[i].keystone_level.ToString();                        
                            break;
                        case 2: tb.Text = data.leading_groups[i].duration.ToString();                           
                            break;
                        case 3:
                            AddGroupMember(data, mainGrid, a, i);
                            a = 7;
                            break;
                        case 8:
                            tb.Text = data.leading_groups[i].completed_timestamp.ToString();                           
                            break;
                    }
                    if (a != 7)
                    {
                        Grid g = new Grid();
                        AddtoGrid(g, mainGrid, tb, a, i);
                    }
                }
            }
        }
        
        private void AddtoGrid(Grid g, Grid mainGrid, TextBlock tb, int a, int i)
        {
            g.Children.Add(tb);
            // Here you set the Grid properties, such as border and alignment
            // You can add other properties and events you need
            g.BorderThickness = new Thickness(1, 2, 1, 2);
            g.BorderBrush = new SolidColorBrush(Colors.Wheat);
            g.HorizontalAlignment = HorizontalAlignment.Stretch;
            g.VerticalAlignment = VerticalAlignment.Stretch;

            // Add the newly created Grid to the outer Grid
            RowDefinition rowHeight = new RowDefinition();
            rowHeight.Height = new GridLength(50);
            mainGrid.RowDefinitions.Add(rowHeight);

            Grid.SetRow(g, i+2);
            Grid.SetColumn(g, a);
            mainGrid.Children.Add(g);
        }

        private void AddGroupMember(MythicRootobject data, Grid mainGrid, int a, int i)
        {
            
            int columnCount = a;
            for (int c = 0; c < 5; c++)
            {
                Grid g = new Grid();
                TextBlock tb = new TextBlock();
                DefineText(tb);
                tb.Text = data.leading_groups[i].members[c].profile.name;
                
                AddtoGrid(g, mainGrid, tb, columnCount, i);
                columnCount++;
            }

        }

        private void cbServer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            
            switch (cbServer.SelectedItem)
            {
                case "Garona":
                    realmIndex = "509";
                    break;
                case "Vol'jin":
                    realmIndex = "510";
                    break;
                case "Sunstrider":
                    realmIndex = "511";
                    break;
            }

            connection = "https://eu.api.battle.net/data/wow/connected-realm/"+realmIndex+"/mythic-leaderboard/"+dungeonIndex+ "/period/641?namespace=dynamic-eu&locale=en_GB&access_token=ugnefz3dkked237rzcd5nnav";
            DestroyGrid();
        }

        private void cbDungeon_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbDungeon.SelectedItem)
            {
                case "Black Rook Hold":
                    dungeonIndex = "199";
                    break;
                case "Darkheart Thicket":
                    dungeonIndex = "198";
                    break;
                case "Eye of Azshara":
                    dungeonIndex = "197";
                    break;
            }
            connection = "https://eu.api.battle.net/data/wow/connected-realm/" + realmIndex + "/mythic-leaderboard/" + dungeonIndex + "/period/641?namespace=dynamic-eu&locale=en_GB&access_token=ugnefz3dkked237rzcd5nnav";
            DestroyGrid();
        }
        private void DestroyGrid()
        {

            for (int i = _childGrid.Children.Count-13; i > 12; i--)
            {
                _childGrid.Children.RemoveAt(i);
            }
            
            
            GetData();
        }
    }
    

}
