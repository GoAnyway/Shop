using System.Collections.ObjectModel;
using System.Windows.Input;
using DataManager.EmployeeRepositories;
using DataManager.SubdivisionRepositories;
using Models.MainModels;
using ShopWPF.Commands.SubdivisionViewModelsCommands;

namespace ShopWPF.ViewModels
{
    public class SubdivisionViewModel : BaseViewModel
    {
        private SubdivisionModel _selectedSubdivision;

        public SubdivisionViewModel(ISubdivisionRepository subdivisionRepository,
            IEmployeeRepository employeeRepository)
        {
            AddSubdivisionCommand = new AddSubdivisionCommand(this);
            DeleteSubdivisionCommand = new DeleteSubdivisionCommand(this, subdivisionRepository);
            SaveSubdivisionsCommand = new SaveSubdivisionsCommand(this, subdivisionRepository);
            RefreshSubdivisionsCommand =
                new RefreshSubdivisionsCommand(this, subdivisionRepository, employeeRepository);

            RefreshSubdivisionsCommand.Execute(null);
        }

        public ObservableCollection<SubdivisionModel> Subdivisions { get; set; } =
            new ObservableCollection<SubdivisionModel>();

        public ObservableCollection<EmployeeModel> Managers { get; set; } =
            new ObservableCollection<EmployeeModel>();

        public SubdivisionModel SelectedSubdivision
        {
            get => _selectedSubdivision;
            set
            {
                _selectedSubdivision = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddSubdivisionCommand { get; set; }
        public ICommand DeleteSubdivisionCommand { get; set; }
        public ICommand SaveSubdivisionsCommand { get; set; }
        public ICommand RefreshSubdivisionsCommand { get; set; }
    }
}