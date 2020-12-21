using AutoMapper;
using Database;
using Database.Entities;
using Models.MainModels;

namespace DataManager.OrderRepositories
{
    public class OrderRepository : BaseRepository<Order, OrderModel>, IOrderRepository
    {
        public OrderRepository(ShopDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}