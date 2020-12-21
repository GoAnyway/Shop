using AutoMapper;
using Database;
using Database.Entities;
using Models.MainModels;

namespace DataManager.SubdivisionRepositories
{
    public class SubdivisionRepository : BaseRepository<Subdivision, SubdivisionModel>, ISubdivisionRepository
    {
        public SubdivisionRepository(ShopDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}