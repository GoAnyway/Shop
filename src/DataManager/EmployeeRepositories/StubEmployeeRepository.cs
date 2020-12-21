using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Entities;
using Database.Entities.Enums;
using Models.MainModels;

namespace DataManager.EmployeeRepositories
{
    public class StubEmployeeRepository : IEmployeeRepository
    {
        private readonly ICollection<Employee> _employees;
        private readonly IMapper _mapper;

        public StubEmployeeRepository(IMapper mapper)
        {
            _mapper = mapper;

            _employees = new List<Employee>
            {
                new Employee
                {
                    FirstName = "John", LastName = "Johnson", DateOfBirth = new DateTime(1969, 12, 28),
                    Gender = Gender.Male
                },
                new Employee
                {
                    FirstName = "David", LastName = "Lee", DateOfBirth = new DateTime(1987, 1, 10),
                    Gender = Gender.Male
                },
                new Employee
                {
                    FirstName = "Maria", LastName = "Brown", DateOfBirth = new DateTime(2000, 7, 20),
                    Gender = Gender.Female
                }
            };
        }

        public async Task<IEnumerable<EmployeeModel>> GetEntitiesAsModels()
        {
            var models = _employees.Select(_ => _mapper.Map<EmployeeModel>(_)).ToList();

            await Task.CompletedTask;
            return models;
        }

        public async Task SaveEntities(IEnumerable<EmployeeModel> models)
        {
            foreach (var model in models)
            {
                var entity = _employees.FirstOrDefault(_ => _.Id == model.Id);
                if (entity == null)
                {
                    entity = new Employee();
                    _employees.Add(entity);
                }

                _mapper.Map(model, entity);
            }

            await Task.CompletedTask;
        }

        public async Task DeleteEntity(EmployeeModel model)
        {
            var entity = _employees.FirstOrDefault(_ => _.Id == model.Id);
            if (entity != null)
            {
                _employees.Remove(entity);
            }

            await Task.CompletedTask;
        }
    }
}