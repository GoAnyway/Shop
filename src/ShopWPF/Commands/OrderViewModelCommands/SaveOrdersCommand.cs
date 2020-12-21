using System;
using System.Windows.Input;
using DataManager.OrderRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.OrderViewModelCommands
{
    public class SaveOrdersCommand : ICommand
    {
        private readonly OrderViewModel _orderViewModel;
        private readonly IOrderRepository _repository;

        public SaveOrdersCommand(OrderViewModel orderViewModel, IOrderRepository repository)
        {
            _orderViewModel = orderViewModel;
            _repository = repository;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            await _repository.SaveEntities(_orderViewModel.Orders);
            _orderViewModel.RefreshOrdersCommand.Execute(null);
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}