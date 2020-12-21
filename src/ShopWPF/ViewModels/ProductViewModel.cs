using System.Collections.ObjectModel;
using System.Windows.Input;
using DataManager.OrderRepositories;
using DataManager.ProductRepositories;
using Models.MainModels;
using ShopWPF.Commands.ProductViewModelCommands;

namespace ShopWPF.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private ProductModel _selectedProduct;

        public ProductViewModel(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            AddProductCommand = new AddProductCommand(this);
            DeleteProductCommand = new DeleteProductCommand(this, productRepository);
            SaveProductsCommand = new SaveProductsCommand(this, productRepository);
            RefreshProductsCommand = new RefreshProductsCommand(this, productRepository, orderRepository);

            RefreshProductsCommand.Execute(null);
        }

        public ObservableCollection<ProductModel> Products { get; set; } =
            new ObservableCollection<ProductModel>();

        public ObservableCollection<OrderModel> Orders { get; set; } =
            new ObservableCollection<OrderModel>();

        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand SaveProductsCommand { get; set; }
        public ICommand RefreshProductsCommand { get; set; }
    }
}