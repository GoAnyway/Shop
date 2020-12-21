using System;
using System.Windows.Input;
using DataManager.EmployeeRepositories;
using DataManager.OrderRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.OrderViewModelCommands
{
    public class RefreshOrdersCommand : ICommand
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly OrderViewModel _orderViewModel;

        public RefreshOrdersCommand(OrderViewModel orderViewModel, IOrderRepository orderRepository,
            IEmployeeRepository employeeRepository)
        {
            _orderViewModel = orderViewModel;
            _orderRepository = orderRepository;
            _employeeRepository = employeeRepository;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            var orders = await _orderRepository.GetEntitiesAsModels();
            var authors = await _employeeRepository.GetEntitiesAsModels();

            _orderViewModel.Orders.Clear();
            _orderViewModel.Authors.Clear();

            foreach (var author in authors)
            {
                _orderViewModel.Authors.Add(author);
            }

            foreach (var order in orders)
            {
                _orderViewModel.Orders.Add(order);
            }
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}