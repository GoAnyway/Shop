using Database.Entities;
using Models.MainModels;

namespace DataManager.ProductRepositories
{
    public interface IProductRepository : IRepository<Product, ProductModel> { }
}