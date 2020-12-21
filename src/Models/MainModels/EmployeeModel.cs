using System;
using Models.MainModels.Enums;

namespace Models.MainModels
{
    public class EmployeeModel : BaseModel
    {
        private DateTime _dateOfBirth;
        private string _firstName;
        private Gender _gender;
        private string _lastName;
        private string _patronymic;
        private Guid? _subdivisionId;

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        public Guid? SubdivisionId
        {
            get => _subdivisionId;
            set
            {
                if (Nullable.Equals(value, _subdivisionId)) return;
                _subdivisionId = value;
                OnPropertyChanged();
            }
        }
    }
}