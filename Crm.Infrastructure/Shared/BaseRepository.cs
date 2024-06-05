using Crm.Domain.Shared;
using Crm.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infrastructure.Shared
{
    public class BaseRepository<TEntity> : IBaseRepositroy<TEntity> where TEntity : BaseEntity
    {
        protected readonly CrmDbContext _context;

        public BaseRepository(CrmDbContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public TEntity? Get(long id)
        {
            return  _context.Set<TEntity>().FirstOrDefault(t => t.Id == id); 
        }

        public async Task<TEntity?> GetAsync(long id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
