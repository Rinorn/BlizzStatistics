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
    public sealed partial class MythicView : Page
    {
        Grid mainGrid = new Grid();
        
        
        public MythicView()
        {
            this.InitializeComponent();
            GetData();
        }

        private async void GetData()
        {
            
            try
            {
                const string url = "https://eu.api.battle.net/data/wow/connected-realm/509/mythic-leaderboard/197/period/630?namespace=dynamic-eu&locale=en_GB&access_token=j6h9s8bbfwxstshzw57df2m4";
                var client = new HttpClient();
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<MythicRootobject>(response);
                CreateGrid(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                GetData();
            }
        }

        private void CreateGrid(MythicRootobject data)
        {   
            MythicRoot.Children.Add(mainGrid);
            
            
                Grid g = new Grid();
                TextBlock tb = new TextBlock();
            tb.Text = data.keystone_affixes.ToString();
                g.Children.Add(tb);
                g.BorderThickness = new Thickness(1, 2, 1, 2);
                g.BorderBrush = new SolidColorBrush(Colors.Black);
                g.HorizontalAlignment = HorizontalAlignment.Stretch;
                g.VerticalAlignment = VerticalAlignment.Stretch;
               
                // Add the newly created Grid to the outer Grid

                RowDefinition rowHeight = new RowDefinition();
                rowHeight.Height = new GridLength(50);
                mainGrid.RowDefinitions.Add(rowHeight);
                ColumnDefinition colWidth = new ColumnDefinition();
                colWidth.Width = new GridLength(166);
                mainGrid.ColumnDefinitions.Add(colWidth);

                Grid.SetRow(g, 1);
                Grid.SetColumn(g, 1);
                mainGrid.Children.Add(g);
            
           
        }
    }
}
