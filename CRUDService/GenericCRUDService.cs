using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SigmaApplication.Models;
using SigmaApplication.Entities;

namespace SigmaApplication.CRUDService
{
    public class GenericCRUDService<TModel> : IGenericCRUDService<TModel>
        where TModel : Entity<long>
    {
        private readonly IMapper _mapper;
        private readonly SigmaContext _dbContext;

        public GenericCRUDService(IMapper mapper, SigmaContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _dbContext.Set<TModel>().ToListAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public async Task<TModel> GetByIdAsync(long id)
        {
            var entity = await _dbContext.Set<TModel>().FindAsync(id);
            return _mapper.Map<TModel>(entity);
        }

        public async Task<TModel> CreateAsync(TModel dto)
        {
            var maxId = await _dbContext.Set<TModel>()
              .DefaultIfEmpty()
              .MaxAsync(e => e == null ? 0 : e.Id);
            dto.Id = maxId + 1;

            var entity = _mapper.Map<TModel>(dto);
            _dbContext.Set<TModel>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TModel>(entity);
        }

        public async Task UpdateAsync(long id, TModel dto)
        {
            var entity = await _dbContext.Set<TModel>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            _mapper.Map(dto, entity);
            _dbContext.Set<TModel>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _dbContext.Set<TModel>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
            _dbContext.Set<TModel>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
