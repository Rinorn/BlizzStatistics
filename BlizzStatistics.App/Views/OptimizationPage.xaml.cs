using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ClassLibrary1;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlizzStatistics.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OptimizationPage : Page
    {
        public SavedCharacter Character;
        public string CharacterName;
        public string CharacterServer;
        public OptimizationPage()
        {
            this.InitializeComponent();
        }

        private async void CharacterListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character = (SavedCharacter) CharacterListView.SelectedItem;
            if (Character != null) CharacterName = Character.name;
            if (Character != null) CharacterServer = Character.realm;

            await BlizzardFacade.GetCharacter(CharacterName, CharacterServer);
        }
    }
}
