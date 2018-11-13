using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using ClassLibrary1;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace BlizzStatistics.App.ViewModels
{
    public class ClassPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassPageViewModel"/> class.
        /// </summary>
        public ClassPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            { }
        }
        
        /// <summary>
        /// The character classes
        /// </summary>
        private ObservableCollection<CharacterClass> _characterClasses;
        /// <summary>
        /// Gets or sets the character classes.
        /// </summary>
        /// <value>
        /// The character classes.
        /// </value>
        public ObservableCollection<CharacterClass> CharacterClasses { get => _characterClasses;
            set => Set(ref _characterClasses, value);
        }
        
        /// <summary>
        /// Called when [navigated to asynchronous].
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="suspensionState">State of the suspension.</param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Called when [navigated from asynchronous].
        /// </summary>
        /// <param name="suspensionState">State of the suspension.</param>
        /// <param name="suspending">if set to <c>true</c> [suspending].</param>
        /// <returns></returns>
        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
            }
            await Task.CompletedTask;
        }
        
        /// <summary>
        /// Raises the <see cref="E:NavigatingFromAsync" /> event.
        /// </summary>
        /// <param name="args">The <see cref="NavigatingEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
    }
}
