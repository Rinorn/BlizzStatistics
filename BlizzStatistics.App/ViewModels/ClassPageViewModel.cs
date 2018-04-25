using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using ClassLibrary1;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace BlizzStatistics.App.ViewModels
{
    public class ClassPageViewModel : ViewModelBase
    {
        public ClassPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            { }

            
        }

        private ObservableCollection<CharacterClass> _characterClasses;
        public ObservableCollection<CharacterClass> CharacterClasses { get { return _characterClasses; } set { Set(ref _characterClasses, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (CharacterClasses == null) // get authors 
            {
                CharacterClasses = new ObservableCollection<CharacterClass>(await DataSource.CharacterClasses.Instance.GetCharacterClasses());
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
