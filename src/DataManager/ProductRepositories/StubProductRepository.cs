using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Entities;
using Models.MainModels;

namespace DataManager.ProductRepositories
{
    public class StubProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly ICollection<Product> _products;

        public StubProductRepository(IMapper mapper)
        {
            _mapper = mapper;

            _products = new List<Product>
            {
                new Product {Name = "Product1", ProductNumber = 123, Price = 781.50M, Count = 10000},
                new Product {Name = "Product2", ProductNumber = 5781, Price = 15000M, Count = 400},
                new Product {Name = "Product3", ProductNumber = 10924, Price = 100M, Count = 550000}
            };
        }

        public async Task<IEnumerable<ProductModel>> GetEntitiesAsModels()
        {
            var models = _products.Select(_ => _mapper.Map<ProductModel>(_)).ToList();

            await Task.CompletedTask;
            return models;
        }

        public async Task SaveEntities(IEnumerable<ProductModel> models)
        {
            foreach (var model in models)
            {
                var entity = _products.FirstOrDefault(_ => _.Id == model.Id);
                if (entity == null)
                {
                    entity = new Product();
                    _products.Add(entity);
                }

                _mapper.Map(model, entity);
            }

            await Task.CompletedTask;
        }

        public async Task DeleteEntity(ProductModel model)
        {
            var entity = _products.FirstOrDefault(_ => _.Id == model.Id);
            if (entity != null)
            {
                _products.Remove(entity);
            }

            await Task.CompletedTask;
        }
    }
}