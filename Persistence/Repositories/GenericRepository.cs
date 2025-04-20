﻿using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> GetAsync(TKey id)
            => await _context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool isTrackable = false)
        {
            if (isTrackable)
                return await _context.Set<TEntity>().ToListAsync();

            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Specification<TEntity> specifications)
    => await ApplySpecification(specifications).ToListAsync();

        public async Task<TEntity> GetAsync(Specification<TEntity> specifications)
            => await ApplySpecification(specifications).FirstOrDefaultAsync();

        private IQueryable<TEntity> ApplySpecification(Specification<TEntity> specifications)
            => SpecificationEvaluator.GetQuery(_context.Set<TEntity>(), specifications);

        public async Task AddAsync(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);
        public async Task<int> CountAsync(Specification<TEntity> specifications)
            => await ApplySpecification(specifications).CountAsync();
    }
}
