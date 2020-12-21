using System;

namespace Models.MainModels
{
    public class SubdivisionModel : BaseModel
    {
        private Guid? _managerId;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public Guid? ManagerId
        {
            get => _managerId;
            set
            {
                if (Nullable.Equals(value, _managerId)) return;
                _managerId = value;
                OnPropertyChanged();
            }
        }
    }
}