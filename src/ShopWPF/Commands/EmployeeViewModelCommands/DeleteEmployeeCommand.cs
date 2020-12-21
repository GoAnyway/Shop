using System;
using System.Windows.Input;
using DataManager.EmployeeRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.EmployeeViewModelCommands
{
    public class DeleteEmployeeCommand : ICommand
    {
        private readonly EmployeeViewModel _employeeViewModel;
        private readonly IEmployeeRepository _repository;

        public DeleteEmployeeCommand(EmployeeViewModel employeeViewModel, IEmployeeRepository repository)
        {
            _employeeViewModel = employeeViewModel;
            _repository = repository;

            _employeeViewModel.PropertyChanged += (sender, args) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter) => _employeeViewModel.SelectedEmployee?.Id != default;

        public async void Execute(object parameter)
        {
            var selectedEmployee = _employeeViewModel.SelectedEmployee;
            await _repository.DeleteEntity(selectedEmployee);
            _employeeViewModel.Employees.Remove(selectedEmployee);
        }

        public event EventHandler CanExecuteChanged;
    }
}