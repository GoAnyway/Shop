using System;
using System.Windows.Input;
using DataManager.SubdivisionRepositories;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.SubdivisionViewModelsCommands
{
    public class SaveSubdivisionsCommand : ICommand
    {
        private readonly ISubdivisionRepository _repository;
        private readonly SubdivisionViewModel _subdivisionViewModel;

        public SaveSubdivisionsCommand(SubdivisionViewModel subdivisionViewModel, ISubdivisionRepository repository)
        {
            _subdivisionViewModel = subdivisionViewModel;
            _repository = repository;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            await _repository.SaveEntities(_subdivisionViewModel.Subdivisions);
            _subdivisionViewModel.RefreshSubdivisionsCommand.Execute(null);
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}