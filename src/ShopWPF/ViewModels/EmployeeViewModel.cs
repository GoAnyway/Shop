using System.Collections.ObjectModel;
using System.Windows.Input;
using DataManager.EmployeeRepositories;
using DataManager.SubdivisionRepositories;
using Models.MainModels;
using ShopWPF.Commands.EmployeeViewModelCommands;

namespace ShopWPF.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        private EmployeeModel _selectedEmployee;

        public EmployeeViewModel(IEmployeeRepository employeeRepository, ISubdivisionRepository subdivisionRepository)
        {
            AddEmployeeCommand = new AddEmployeeCommand(this);
            DeleteEmployeeCommand = new DeleteEmployeeCommand(this, employeeRepository);
            SaveEmployeesCommand = new SaveEmployeesCommand(this, employeeRepository);
            RefreshEmployeesCommand = new RefreshEmployeesCommand(this, employeeRepository, subdivisionRepository);

            RefreshEmployeesCommand.Execute(null);
        }

        public ObservableCollection<EmployeeModel> Employees { get; set; } =
            new ObservableCollection<EmployeeModel>();

        public ObservableCollection<SubdivisionModel> Subdivisions { get; set; } =
            new ObservableCollection<SubdivisionModel>();

        public EmployeeModel SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddEmployeeCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }
        public ICommand SaveEmployeesCommand { get; set; }
        public ICommand RefreshEmployeesCommand { get; set; }
    }
}