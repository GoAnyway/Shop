using ShopWPF.Navigators;

namespace ShopWPF.ViewModels.Factories
{
    public interface IShopViewModelFactory
    {
        BaseViewModel CreateViewModel(ViewModelType viewModelType);
    }
}