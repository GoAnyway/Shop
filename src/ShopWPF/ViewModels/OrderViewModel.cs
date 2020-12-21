using System.Collections.ObjectModel;
using System.Windows.Input;
using DataManager.EmployeeRepositories;
using DataManager.OrderRepositories;
using Models.MainModels;
using ShopWPF.Commands.OrderViewModelCommands;

namespace ShopWPF.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private OrderModel _selectedOrder;

        public OrderViewModel(IOrderRepository orderRepository, IEmployeeRepository employeeRepository)
        {
            AddOrderCommand = new AddOrderCommand(this);
            DeleteOrderCommand = new DeleteOrderCommand(this, orderRepository);
            SaveOrdersCommand = new SaveOrdersCommand(this, orderRepository);
            RefreshOrdersCommand = new RefreshOrdersCommand(this, orderRepository, employeeRepository);

            RefreshOrdersCommand.Execute(null);
        }

        public ObservableCollection<OrderModel> Orders { get; set; } =
            new ObservableCollection<OrderModel>();

        public ObservableCollection<EmployeeModel> Authors { get; set; } =
            new ObservableCollection<EmployeeModel>();

        public OrderModel SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand SaveOrdersCommand { get; set; }
        public ICommand RefreshOrdersCommand { get; set; }
    }
}