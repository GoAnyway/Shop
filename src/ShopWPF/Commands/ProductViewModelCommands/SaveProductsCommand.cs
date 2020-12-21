using System;
using System.Windows.Input;
using DataManager.ProductRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.ProductViewModelCommands
{
    public class SaveProductsCommand : ICommand
    {
        private readonly ProductViewModel _productViewModel;
        private readonly IProductRepository _repository;

        public SaveProductsCommand(ProductViewModel productViewModel, IProductRepository repository)
        {
            _productViewModel = productViewModel;
            _repository = repository;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            await _repository.SaveEntities(_productViewModel.Products);
            _productViewModel.RefreshProductsCommand.Execute(null);
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}