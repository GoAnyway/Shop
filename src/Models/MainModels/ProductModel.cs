using System;

namespace Models.MainModels
{
    public class ProductModel : BaseModel
    {
        private int _count;
        private string _name;
        private Guid? _orderId;
        private decimal _price;
        private int _productNumber;

        public int ProductNumber
        {
            get => _productNumber;
            set
            {
                _productNumber = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        public Guid? OrderId
        {
            get => _orderId;
            set
            {
                if (Nullable.Equals(value, _orderId)) return;
                _orderId = value;
                OnPropertyChanged();
            }
        }
    }
}