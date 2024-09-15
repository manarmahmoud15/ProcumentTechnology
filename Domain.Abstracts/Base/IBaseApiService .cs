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
    public interface IBaseApiService<T, TDto, TGetDto, TKey , TKeyDto>
        where T : PrimEntityDto<TKey>
        where TDto : IEntityDto<TKeyDto>
        where TGetDto : IEntityDto<TKeyDto>
    {
        Task<IEnumerable<TGetDto>> GetAllAsync(bool disableTracking = false);
        Task<DataPaging> FindPagedAsync(Expression<Func<T, bool>> predicate = null, int PageSize = 0, int PageNumber = 0, IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true);
        Task<T> AddAsync(TDto model);
        Task<List<T>> AddListAsync(List<TDto> model);
        Task<T> UpdateAsync(TDto model);
        Task<T> UpdateModelAsync(T model);
        Task<string> DeleteAsync(TKey id);
        Task<string> DeleteSoftAsync(TKey id);
        Task<TGetDto> GetByIdAsync(TKey id);
        Task<T> GetModelByIdAsync(TKey id);
        Task<ICollection<T>> FindAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true);
    }
}