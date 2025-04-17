﻿using Domain.Contracts;
using Domain.Entities;
using Persistence.Data;
using Persistence.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<string, object>();
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            => _repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(_context)) as IGenericRepository<TEntity, TKey>;

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
