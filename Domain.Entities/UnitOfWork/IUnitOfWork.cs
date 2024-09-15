using Medianesta.DataLayer.Base;
using Domain.Entities.Context;
using Library.Helpers.Repository;
using System;
using System.Threading.Tasks;

namespace Library.Helpers.UnitOfWork
{
    public interface IUnitOfWork<T, TKey> : IDisposable where T : PrimEntityDto<TKey>
    {
        IRepository<T> Repository { get; }
        IRepository<TB> GetRepository<TB>() where TB : class;
        Task<int> SaveChanges();
        void StartTransaction();
        void CommitTransaction();
        void Rollback();
    }


}
