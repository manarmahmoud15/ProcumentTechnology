using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Medianesta.DataLayer.Base;
using Library.Helpers.APIUtilities;
using Library.Helpers.Extensions;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Services.Base
{
    public interface IBaseService<T, TDto, TGetDto, TKey , TKeyDto>
        where T : GeneralTable<TKey>
        where TDto : IEntityDto<TKeyDto>
        where TGetDto : IEntityDto<TKeyDto>
    {
        Task<IEnumerable<TGetDto>> GetAllAsync(bool disableTracking = false);
        Task<IEnumerable<TGetDto>> GetAllAsyncWithFilter(Expression<Func<T, bool>> predicate = null, IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking =false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<DataPaging<T>> FindPagedAsync(Expression<Func<T, bool>> predicate = null, int PageSize = 0, int PageNumber = 0, IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = false);
        Task<IEnumerable<T>> GetAllEntityAsyncWithFilter(Expression<Func<T, bool>> predicate = null, IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<Tuple<bool, TKey>> AddAsync(TDto model);
        Task<bool> AddListAsync(List<TDto> model);
        Task<bool> UpdateAsync(TDto model);
        Task<bool> DeleteAsync(long id);
        Task<bool> DeleteSoftAsync(long id);
        Task<TGetDto> GetByIdAsync(long id);

    }
}