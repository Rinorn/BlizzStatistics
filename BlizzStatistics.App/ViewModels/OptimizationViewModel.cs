﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using ClassLibrary1;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace BlizzStatistics.App.ViewModels
{
    public class DeleteSavedCharacterCommand : ICommand
    {
        private OptimizationViewModel _viewModel;

        public DeleteSavedCharacterCommand(OptimizationViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        //This need be here, or else  the ICommand would not be implementet
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => parameter != null;

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                if (await DataSource.SavedCharacters.Instance.DeleteSavedCharacter((SavedCharacter)parameter))
                    _viewModel.SavedCharacters.Remove(((SavedCharacter)parameter));
            }
        }
    }

    public class OptimizationViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationViewModel"/> class.
        /// </summary>
        public OptimizationViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            { }
            DeleteSavedCharacterCommand = new DeleteSavedCharacterCommand(this); 
        }

        /// <summary>
        /// The saved characters
        /// </summary>
        private ObservableCollection<SavedCharacter> _savedCharacters;
        /// <summary>
        /// Gets or sets the saved characters.
        /// </summary>
        /// <value>
        /// The saved characters.
        /// </value>
        public ObservableCollection<SavedCharacter> SavedCharacters{get => _savedCharacters;
            set => Set(ref _savedCharacters, value);         
        }
        private ObservableCollection<Equipment> _equipments;
        public ObservableCollection<Equipment> Equipments
        {
            get => _equipments;
            set => Set(ref _equipments, value); 
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
            if (SavedCharacters == null) 
            {
                SavedCharacters = new ObservableCollection<SavedCharacter>(await DataSource.SavedCharacters.Instance.GetSavedCharacter());
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

        public ICommand DeleteSavedCharacterCommand { get; set; }
    }
}
