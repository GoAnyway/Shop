using System;
using System.Windows.Input;
using Models.MainModels;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.ProductViewModelCommands
{
    public class AddProductCommand : ICommand
    {
        private readonly ProductViewModel _productViewModel;

        public AddProductCommand(ProductViewModel productViewModel)
        {
            _productViewModel = productViewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _productViewModel.Products.Add(new ProductModel());

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}