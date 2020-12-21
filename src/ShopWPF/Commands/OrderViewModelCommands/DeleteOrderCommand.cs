using System;
using System.Windows.Input;
using DataManager.OrderRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.OrderViewModelCommands
{
    public class DeleteOrderCommand : ICommand
    {
        private readonly OrderViewModel _orderViewModel;
        private readonly IOrderRepository _repository;

        public DeleteOrderCommand(OrderViewModel orderViewModel, IOrderRepository repository)
        {
            _orderViewModel = orderViewModel;
            _repository = repository;

            _orderViewModel.PropertyChanged += (sender, args) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter) => _orderViewModel.SelectedOrder?.Id != default;

        public async void Execute(object parameter)
        {
            var selectedOrder = _orderViewModel.SelectedOrder;
            await _repository.DeleteEntity(selectedOrder);
            _orderViewModel.Orders.Remove(selectedOrder);
        }

        public event EventHandler CanExecuteChanged;
    }
}