using EnsolversBL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsolversBL.Data.EFCore
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly EnsolversContext context;
        public BaseRepository(EnsolversContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return entity;
            }
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var item = await context.Set<TEntity>().FindAsync(id);
            return item;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
