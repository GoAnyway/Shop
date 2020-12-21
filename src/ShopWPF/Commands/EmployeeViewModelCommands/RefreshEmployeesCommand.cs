using System;
using System.Windows.Input;
using DataManager.EmployeeRepositories;
using DataManager.SubdivisionRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.EmployeeViewModelCommands
{
    public class RefreshEmployeesCommand : ICommand
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeViewModel _employeeViewModel;
        private readonly ISubdivisionRepository _subdivisionRepository;

        public RefreshEmployeesCommand(EmployeeViewModel employeeViewModel, IEmployeeRepository employeeRepository,
            ISubdivisionRepository subdivisionRepository)
        {
            _employeeViewModel = employeeViewModel;
            _employeeRepository = employeeRepository;
            _subdivisionRepository = subdivisionRepository;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            var employees = await _employeeRepository.GetEntitiesAsModels();
            var subdivisions = await _subdivisionRepository.GetEntitiesAsModels();

            _employeeViewModel.Employees.Clear();
            _employeeViewModel.Subdivisions.Clear();

            foreach (var subdivision in subdivisions)
            {
                _employeeViewModel.Subdivisions.Add(subdivision);
            }

            foreach (var employee in employees)
            {
                _employeeViewModel.Employees.Add(employee);
            }
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}