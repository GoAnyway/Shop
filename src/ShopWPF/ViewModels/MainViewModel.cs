using System.Windows.Input;
using ShopWPF.Commands.MainViewModelCommands;
using ShopWPF.Navigators;
using ShopWPF.ViewModels.Factories;

namespace ShopWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;

        public MainViewModel(INavigator navigator, IShopViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _navigator.StateChanged += () => { OnPropertyChanged(nameof(CurrentViewModel)); };

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewModelType.Employee);
        }

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; set; }
    }
}