using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using ClassLibrary1;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace BlizzStatistics.App.ViewModels
{
    public class RealmViewModel : ViewModelBase
    {
        public RealmViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            { }
        }

        /// <summary>
        /// The character races
        /// </summary>
        private ObservableCollection<Realm> _realms;
        /// <summary>
        /// Gets or sets the character races.
        /// </summary>
        /// <value>
        /// The character races.
        /// </value>
        public ObservableCollection<Realm> Realms
        {
            get => _realms;
            set => Set(ref _realms, value);
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
            if (Realms == null)
            {
                Realms = new ObservableCollection<Realm>(await DataSource.Realms.Instance.GetRealm());
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
