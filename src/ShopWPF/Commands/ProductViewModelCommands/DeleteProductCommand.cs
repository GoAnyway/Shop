using System;
using System.Windows.Input;
using DataManager.ProductRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.ProductViewModelCommands
{
    public class DeleteProductCommand : ICommand
    {
        private readonly ProductViewModel _productViewModel;
        private readonly IProductRepository _repository;

        public DeleteProductCommand(ProductViewModel productViewModel, IProductRepository repository)
        {
            _productViewModel = productViewModel;
            _repository = repository;

            _productViewModel.PropertyChanged += (sender, args) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter) => _productViewModel.SelectedProduct?.Id != default;

        public async void Execute(object parameter)
        {
            var selectedProduct = _productViewModel.SelectedProduct;
            await _repository.DeleteEntity(selectedProduct);
            _productViewModel.Products.Remove(selectedProduct);
        }

        public event EventHandler CanExecuteChanged;
    }
}