using System;
using ShopWPF.ViewModels;

namespace ShopWPF.Navigators
{
    public enum ViewModelType
    {
        Employee,
        Subdivision,
        Order,
        Product
    }

    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}