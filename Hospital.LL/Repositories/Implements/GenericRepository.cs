using Hospital.BL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace Hospital.LL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly HospitalContext _hospitalContext;

        public GenericRepository(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }
        public async Task Delete(int id)
        {
            TEntity entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception("The entity is null");

            }

            _hospitalContext.Set<TEntity>().Remove(entity);
            await _hospitalContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _hospitalContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _hospitalContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            _hospitalContext.Set<TEntity>().Add(entity);
            await _hospitalContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _hospitalContext.Set<TEntity>().AddOrUpdate(entity);
            await _hospitalContext.SaveChangesAsync();
            return entity;
        }
    }
}
