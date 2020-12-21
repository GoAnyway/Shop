using System;
using System.Windows.Input;
using DataManager.EmployeeRepositories;
using DataManager.SubdivisionRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.SubdivisionViewModelsCommands
{
    public class RefreshSubdivisionsCommand : ICommand
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISubdivisionRepository _subdivisionRepository;
        private readonly SubdivisionViewModel _subdivisionViewModel;

        public RefreshSubdivisionsCommand(SubdivisionViewModel subdivisionViewModel,
            ISubdivisionRepository subdivisionRepository,
            IEmployeeRepository employeeRepository)
        {
            _subdivisionViewModel = subdivisionViewModel;
            _subdivisionRepository = subdivisionRepository;
            _employeeRepository = employeeRepository;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            var subdivisions = await _subdivisionRepository.GetEntitiesAsModels();
            var managers = await _employeeRepository.GetEntitiesAsModels();

            _subdivisionViewModel.Subdivisions.Clear();
            _subdivisionViewModel.Managers.Clear();

            foreach (var manager in managers)
            {
                _subdivisionViewModel.Managers.Add(manager);
            }

            foreach (var subdivision in subdivisions)
            {
                _subdivisionViewModel.Subdivisions.Add(subdivision);
            }
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}