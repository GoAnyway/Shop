using AutoMapper;
using Database;
using Database.Entities;
using Models.MainModels;

namespace DataManager.ProductRepositories
{
    public class ProductRepository : BaseRepository<Product, ProductModel>, IProductRepository
    {
        public ProductRepository(ShopDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}