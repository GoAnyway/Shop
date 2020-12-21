using AutoMapper;
using Database;
using Database.Entities;
using Models.MainModels;

namespace DataManager.EmployeeRepositories
{
    public class EmployeeRepository : BaseRepository<Employee, EmployeeModel>, IEmployeeRepository
    {
        public EmployeeRepository(ShopDbContext context, IMapper mapper)
            : base(context, mapper) { }
    }
}