using System;
using ShopWPF.Navigators;

namespace ShopWPF.ViewModels.Factories
{
    public class ShopViewModelFactory : IShopViewModelFactory
    {
        private readonly CreateViewModel<EmployeeViewModel> _createEmployeeViewModel;
        private readonly CreateViewModel<OrderViewModel> _createOrderViewModel;
        private readonly CreateViewModel<ProductViewModel> _createProductViewModel;
        private readonly CreateViewModel<SubdivisionViewModel> _createSubdivisionViewModel;

        public ShopViewModelFactory(CreateViewModel<EmployeeViewModel> createEmployeeViewModel,
            CreateViewModel<SubdivisionViewModel> createSubdivisionViewModel,
            CreateViewModel<OrderViewModel> createOrderViewModel,
            CreateViewModel<ProductViewModel> createProductViewModel)
        {
            _createEmployeeViewModel = createEmployeeViewModel;
            _createSubdivisionViewModel = createSubdivisionViewModel;
            _createOrderViewModel = createOrderViewModel;
            _createProductViewModel = createProductViewModel;
        }

        public BaseViewModel CreateViewModel(ViewModelType viewModelType) =>
            viewModelType switch
            {
                ViewModelType.Employee => _createEmployeeViewModel(),
                ViewModelType.Subdivision => _createSubdivisionViewModel(),
                ViewModelType.Order => _createOrderViewModel(),
                ViewModelType.Product => _createProductViewModel(),
                _ => throw new ArgumentOutOfRangeException("This ViewModelType does not have a ViewModel.",
                    nameof(viewModelType))
            };
    }
}