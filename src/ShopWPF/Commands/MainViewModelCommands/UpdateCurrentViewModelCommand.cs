using System;
using System.Windows.Input;
using ShopWPF.Navigators;
using ShopWPF.ViewModels.Factories;

namespace ShopWPF.Commands.MainViewModelCommands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;
        private readonly IShopViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IShopViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (parameter is ViewModelType viewModelType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewModelType);
            }
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}