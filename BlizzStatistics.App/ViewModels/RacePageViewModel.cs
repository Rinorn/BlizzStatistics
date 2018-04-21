using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using ClassLibrary1;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace BlizzStatistics.App.ViewModels
{
    public class RacePageViewModel : ViewModelBase
    {
        public RacePageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            { }


        }

        private ObservableCollection<CharacterRace> characterRaces;
        public ObservableCollection<CharacterRace> CharacterRaces { get { return characterRaces; } set { Set(ref characterRaces, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (CharacterRaces == null)
            {
                CharacterRaces = new ObservableCollection<CharacterRace>(await DataSource.CharacterRaces.Instance.GetCharacterRaces());
            }

            if (suspensionState.Any())
            {
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public ICommand DeleteAuthorCommand { get; set; }
    }
}
