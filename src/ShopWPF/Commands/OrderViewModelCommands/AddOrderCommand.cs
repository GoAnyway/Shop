using System;
using System.Windows.Input;
using Models.MainModels;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.OrderViewModelCommands
{
    public class AddOrderCommand : ICommand
    {
        private readonly OrderViewModel _orderViewModel;

        public AddOrderCommand(OrderViewModel orderViewModel)
        {
            _orderViewModel = orderViewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _orderViewModel.Orders.Add(new OrderModel());

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}