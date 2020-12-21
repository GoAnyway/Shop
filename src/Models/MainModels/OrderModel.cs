using System;

namespace Models.MainModels
{
    public class OrderModel : BaseModel
    {
        private Guid? _authorId;
        private string _counterpartyName;
        private DateTime _orderDate;
        private int _orderNumber;

        public int OrderNumber
        {
            get => _orderNumber;
            set
            {
                _orderNumber = value;
                OnPropertyChanged();
            }
        }

        public string CounterpartyName
        {
            get => _counterpartyName;
            set
            {
                _counterpartyName = value;
                OnPropertyChanged();
            }
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set
            {
                _orderDate = value;
                OnPropertyChanged();
            }
        }

        public Guid? AuthorId
        {
            get => _authorId;
            set
            {
                if (Nullable.Equals(value, _authorId)) return;
                _authorId = value;
                OnPropertyChanged();
            }
        }
    }
}