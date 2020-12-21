using System;
using System.Windows.Input;
using DataManager.SubdivisionRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.SubdivisionViewModelsCommands
{
    public class DeleteSubdivisionCommand : ICommand
    {
        private readonly ISubdivisionRepository _repository;
        private readonly SubdivisionViewModel _subdivisionViewModel;

        public DeleteSubdivisionCommand(SubdivisionViewModel subdivisionViewModel, ISubdivisionRepository repository)
        {
            _subdivisionViewModel = subdivisionViewModel;
            _repository = repository;

            _subdivisionViewModel.PropertyChanged += (sender, args) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter) => _subdivisionViewModel.SelectedSubdivision?.Id != default;

        public async void Execute(object parameter)
        {
            var selectedSubdivision = _subdivisionViewModel.SelectedSubdivision;
            await _repository.DeleteEntity(selectedSubdivision);
            _subdivisionViewModel.Subdivisions.Remove(selectedSubdivision);
        }

        public event EventHandler CanExecuteChanged;
    }
}