using System;
using System.Windows.Input;
using DataManager.OrderRepositories;
using DataManager.ProductRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.ProductViewModelCommands
{
    public class RefreshProductsCommand : ICommand
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ProductViewModel _productViewModel;

        public RefreshProductsCommand(ProductViewModel productViewModel, IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _productViewModel = productViewModel;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            var products = await _productRepository.GetEntitiesAsModels();
            var orders = await _orderRepository.GetEntitiesAsModels();

            _productViewModel.Products.Clear();
            _productViewModel.Orders.Clear();

            foreach (var order in orders)
            {
                _productViewModel.Orders.Add(order);
            }

            foreach (var order in products)
            {
                _productViewModel.Products.Add(order);
            }
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}