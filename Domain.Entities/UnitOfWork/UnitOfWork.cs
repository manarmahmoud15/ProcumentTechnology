using Medianesta.DataLayer.Base;
using Domain.Entities.Context;
using Library.Helpers.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Helpers.UnitOfWork
{
    public class UnitOfWork<T, TKey> : IUnitOfWork<T, TKey> where T : PrimEntityDto<TKey>
    {
        private DbContext _context;
        private IDbContextTransaction _transaction;
        private Dictionary<string, dynamic> _repositories;
        public IRepository<T> Repository { get; }
        public UnitOfWork(DbContext context)
        {
            _context = context;
            Repository = new Repository<T>(_context);
        }

        public IRepository<TB> GetRepository<TB>() where TB : class
        {
            _repositories ??= new Dictionary<string, dynamic>();
            var type = typeof(TB).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepository<TB>)_repositories[type];
            }

            var repositoryType = typeof(Repository<TB>);
            var repository = Activator.CreateInstance(repositoryType, _context);
            _repositories.Add(type, repository);
            return _repositories[type];
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public void StartTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _transaction.Commit();
            _transaction.Dispose();
        }
        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_context == null)
            {
                return;
            }

            _context.Dispose();
            _context = null;
        }
    }

}
