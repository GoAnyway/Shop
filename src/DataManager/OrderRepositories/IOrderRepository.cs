using Database.Entities;
using Models.MainModels;

namespace DataManager.OrderRepositories
{
    public interface IOrderRepository : IRepository<Order, OrderModel> { }
}