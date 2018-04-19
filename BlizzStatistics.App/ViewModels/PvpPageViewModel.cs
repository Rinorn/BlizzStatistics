using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Services.KeyboardService;
using Template10.Services.NavigationService;

namespace BlizzStatistics.App.ViewModels
{
    class PvpPageViewModel
    {



        public async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
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
        public async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
    }

}