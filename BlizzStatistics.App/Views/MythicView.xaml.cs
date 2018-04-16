using System;
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
        
        


        public MythicView()
        {
            this.InitializeComponent();
            GetData();
        }

        private async void GetData()
        {
            
            try
            {
                Uri ur = new Uri("https://eu.api.battle.net/data/wow/connected-realm/509/mythic-leaderboard/197/period/630?namespace=dynamic-eu&locale=en_GB&access_token=j6h9s8bbfwxstshzw57df2m4");
                var client = new HttpClient();
                var response = await client.GetStringAsync(ur);
                var data = JsonConvert.DeserializeObject<MythicRootobject>(response);
                AddToColumns(data);
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
            Grid mainGrid = new Grid();
            //RelativePanel.SetAlignLeftWithPanel(MenuGrid, true);
            //RelativePanel.SetAlignRightWithPanel(MenuGrid, true);
            MythicRoot.Children.Add(mainGrid);
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
                            colWidth.Width = new GridLength(Column1.ActualWidth);
                            break;
                        case 1:
                            tb.Text = data.leading_groups[i].keystone_level.ToString();
                            colWidth.Width = new GridLength(Column2.ActualWidth);
                            break;
                        case 2: tb.Text = data.leading_groups[i].duration.ToString();
                            colWidth.Width = new GridLength(Column3.ActualWidth);
                            break;
                        case 3:
                            AddGroupMember(data, mainGrid, a, colWidth, i);
                            a = 7;
                            break;
                        case 8:
                            tb.Text = data.leading_groups[i].completed_timestamp.ToString();
                            colWidth.Width = new GridLength(Column9.ActualWidth);
                            break;
                    }
                    
                    if (a != 7)
                    {
                        Grid g = new Grid();
                        AddtoGrid(g, mainGrid, tb, a, colWidth, i);
                    }
                }
            }
        }
        
        private void AddtoGrid(Grid g, Grid mainGrid, TextBlock tb, int a, ColumnDefinition columnWidth, int i)
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
            mainGrid.ColumnDefinitions.Add(columnWidth);

            Grid.SetRow(g, i);
            Grid.SetColumn(g, a);
            mainGrid.Children.Add(g);
        }

        private void AddGroupMember(MythicRootobject data, Grid mainGrid, int a, ColumnDefinition colWidth, int i)
        {
            
            int columnCount = a;
            for (int c = 0; c < 5; c++)
            {
                Grid g = new Grid();
                TextBlock tb = new TextBlock();
                DefineText(tb);
                tb.Text = data.leading_groups[i].members[c].profile.name;
                ColumnDefinition colW = new ColumnDefinition();
                colW.Width = new GridLength(Column3.ActualWidth + Column3.ActualWidth * 1 / 5);
                AddtoGrid(g, mainGrid, tb, columnCount, colW, i);
                columnCount++;
            }

        }
    }
    

}
