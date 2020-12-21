using System;
using System.Windows.Input;
using Models.MainModels;
using ShopWPF.ViewModels;

namespace ShopWPF.Commands.SubdivisionViewModelsCommands
{
    public class AddSubdivisionCommand : ICommand
    {
        private readonly SubdivisionViewModel _subdivisionViewModel;

        public AddSubdivisionCommand(SubdivisionViewModel subdivisionViewModel)
        {
            _subdivisionViewModel = subdivisionViewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _subdivisionViewModel.Subdivisions.Add(new SubdivisionModel());

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}