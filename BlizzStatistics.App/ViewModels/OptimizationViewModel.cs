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
    class OptimizationViewModel : ViewModelBase
    {

        public OptimizationViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            { }


        }

        


        private ObservableCollection<SavedCharacter> savedCharacters;
        public  ObservableCollection<SavedCharacter> SavedCharacters{get { return savedCharacters; }set { Set(ref savedCharacters, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            
            if (SavedCharacters == null) // get authors 
            {
                SavedCharacters = new ObservableCollection<SavedCharacter>(await DataSource.SavedCharacters.Instance.GetSavedCharacter());
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
