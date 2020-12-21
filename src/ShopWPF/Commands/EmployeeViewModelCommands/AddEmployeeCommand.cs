using System;
using System.Windows.Input;
using Models.MainModels;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.EmployeeViewModelCommands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeViewModel _employeeViewModel;

        public AddEmployeeCommand(EmployeeViewModel employeeViewModel)
        {
            _employeeViewModel = employeeViewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _employeeViewModel.Employees.Add(new EmployeeModel());

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}