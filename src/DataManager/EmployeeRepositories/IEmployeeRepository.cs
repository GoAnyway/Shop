using Database.Entities;
using Models.MainModels;

namespace DataManager.EmployeeRepositories
{
    public interface IEmployeeRepository : IRepository<Employee, EmployeeModel> { }
}