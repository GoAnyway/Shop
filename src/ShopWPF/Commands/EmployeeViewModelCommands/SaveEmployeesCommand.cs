using System;
using System.Windows.Input;
using DataManager.EmployeeRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.EmployeeViewModelCommands
{
    public class SaveEmployeesCommand : ICommand
    {
        private readonly EmployeeViewModel _employeeViewModel;
        private readonly IEmployeeRepository _repository;

        public SaveEmployeesCommand(EmployeeViewModel employeeViewModel, IEmployeeRepository repository)
        {
            _employeeViewModel = employeeViewModel;
            _repository = repository;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            await _repository.SaveEntities(_employeeViewModel.Employees);
            _employeeViewModel.RefreshEmployeesCommand.Execute(null);
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}