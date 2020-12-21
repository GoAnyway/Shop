using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Entities;
using Models.MainModels;

namespace DataManager.OrderRepositories
{
    public class StubOrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly ICollection<Order> _orders;

        public StubOrderRepository(IMapper mapper)
        {
            _mapper = mapper;

            _orders = new List<Order>
            {
                new Order
                {
                    OrderNumber = 1002, CounterpartyName = "BestCompany", OrderDate = new DateTime(2019, 12, 20)
                },
                new Order {OrderNumber = 1002, CounterpartyName = "Microsoft", OrderDate = new DateTime(2020, 1, 1)},
                new Order {OrderNumber = 1002, CounterpartyName = "Apple", OrderDate = new DateTime(2015, 5, 13)}
            };
        }

        public async Task<IEnumerable<OrderModel>> GetEntitiesAsModels()
        {
            var models = _orders.Select(_ => _mapper.Map<OrderModel>(_)).ToList();

            await Task.CompletedTask;
            return models;
        }

        public async Task SaveEntities(IEnumerable<OrderModel> models)
        {
            foreach (var model in models)
            {
                var entity = _orders.FirstOrDefault(_ => _.Id == model.Id);
                if (entity == null)
                {
                    entity = new Order();
                    _orders.Add(entity);
                }

                _mapper.Map(model, entity);
            }

            await Task.CompletedTask;
        }

        public async Task DeleteEntity(OrderModel model)
        {
            var entity = _orders.FirstOrDefault(_ => _.Id == model.Id);
            if (entity != null)
            {
                _orders.Remove(entity);
            }

            await Task.CompletedTask;
        }
    }
}