using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Entities;
using Models.MainModels;

namespace DataManager.SubdivisionRepositories
{
    public class StubSubdivisionRepository : ISubdivisionRepository
    {
        private readonly IMapper _mapper;
        private readonly ICollection<Subdivision> _subdivisions;

        public StubSubdivisionRepository(IMapper mapper)
        {
            _mapper = mapper;

            _subdivisions = new List<Subdivision>
            {
                new Subdivision {Name = "Subdivision1"},
                new Subdivision {Name = "Subdivision2"},
                new Subdivision {Name = "Subdivision3"}
            };
        }

        public async Task<IEnumerable<SubdivisionModel>> GetEntitiesAsModels()
        {
            var models = _subdivisions.Select(_ => _mapper.Map<SubdivisionModel>(_)).ToList();

            await Task.CompletedTask;
            return models;
        }

        public async Task SaveEntities(IEnumerable<SubdivisionModel> models)
        {
            foreach (var model in models)
            {
                var entity = _subdivisions.FirstOrDefault(_ => _.Id == model.Id);
                if (entity == null)
                {
                    entity = new Subdivision();
                    _subdivisions.Add(entity);
                }

                _mapper.Map(model, entity);
            }

            await Task.CompletedTask;
        }

        public async Task DeleteEntity(SubdivisionModel model)
        {
            var entity = _subdivisions.FirstOrDefault(_ => _.Id == model.Id);
            if (entity != null)
            {
                _subdivisions.Remove(entity);
            }

            await Task.CompletedTask;
        }
    }
}