using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Entities;
using Models.MainModels;

namespace DataManager
{
    public interface IRepository<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        Task<IEnumerable<TModel>> GetEntitiesAsModels();
        Task SaveEntities(IEnumerable<TModel> models);
        Task DeleteEntity(TModel model);
    }
}