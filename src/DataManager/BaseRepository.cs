using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Models.MainModels;

namespace DataManager
{
    public abstract class BaseRepository<TEntity, TModel> : IRepository<TEntity, TModel>
        where TEntity : BaseEntity, new()
        where TModel : BaseModel
    {
        protected readonly ShopDbContext Context;
        protected readonly IMapper Mapper;

        protected BaseRepository(ShopDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual async Task<IEnumerable<TModel>> GetEntitiesAsModels() =>
            await Context.Set<TEntity>().ProjectTo<TModel>(Mapper.ConfigurationProvider).ToListAsync();

        public virtual async Task SaveEntities(IEnumerable<TModel> models)
        {
            foreach (var model in models)
            {
                var entity = await Context.Set<TEntity>().FindAsync(model.Id);
                if (entity == null)
                {
                    entity = new TEntity();
                    await Context.Set<TEntity>().AddAsync(entity);
                }

                Mapper.Map(model, entity);
            }

            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteEntity(TModel model)
        {
            var entity = await Context.Set<TEntity>().FindAsync(model.Id);
            if (entity != null)
            {
                Context.Set<TEntity>().Remove(entity);
                await Context.SaveChangesAsync();
            }
        }
    }
}