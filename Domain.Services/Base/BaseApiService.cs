using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Medianesta.DataLayer.Base;
using AutoMapper;
using Domain.Entities.Context;
using Library.Helpers.AdoModeule;
using Library.Helpers.APIUtilities;
using Library.Helpers.Extensions;
using Library.Helpers.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using Models.ViewModel.Category;
using Service.SharedKernel.Exceptions;

namespace Domain.Services.Base
{
    public class BaseApiService<T, TDto, TGetDto, TKey, TKeyDto>
        : IBaseApiService<T, TDto, TGetDto, TKey, TKeyDto>
        where T : PrimEntityDto<TKey>
        where TDto : IEntityDto<TKeyDto>
        where TGetDto : IEntityDto<TKeyDto>
    {
        protected readonly IUnitOfWork<T, TKey> _unitOfWork;
        protected IRepositoryActionResult _repositoryActionResult { get; set; }
        protected readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IDbHandler _db;
        public UserVm model;


        internal BaseApiService(IUnitOfWork<T, TKey> UnitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper = null, IDbHandler db = null)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
            model = new UserVm();
            // For testing, set up the mock HttpContextAccessor here
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["UserId"] = "1";
            httpContext.Request.Headers["Name"] = "Test User";
            _httpContextAccessor.HttpContext = httpContext;
        }

        internal BaseApiService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<T, TKey> UnitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper = null, IDbHandler db = null)
        {
            _unitOfWork = UnitOfWork;
            _repositoryActionResult = repositoryActionResult;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
            model = new UserVm();

        }
        public virtual async Task<IEnumerable<TGetDto>> GetAllAsync(bool disableTracking = false)
        {
            var query = await _unitOfWork.Repository.GetAllAsync(disableTracking: disableTracking);
            var data = _mapper.Map<IEnumerable<T>, IEnumerable<TGetDto>>(query);
            return data;

            //  return data;
        }
        public async Task<DataPaging> FindPagedAsync(Expression<Func<T, bool>> predicate = null, int PageSize = 0, int PageNumber = 0, IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            int take = PageSize;
            int skip = ((--PageNumber) * PageSize);
            var query = await _unitOfWork.Repository.FindPagedAsync(predicate, skip, take, orderByCriteria, include, disableTracking);
            var res = _mapper.Map<IEnumerable<TGetDto>>(query.Item2);
            var data = new DataPaging(++PageNumber, PageSize, query.Item1, res);
            return data;
        }
        public async Task<ICollection<T>> FindAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            var query = await _unitOfWork.Repository.FindAsync(predicate, null, include, disableTracking);
            return query.ToList();
        }

        public virtual async Task<T> AddAsync(TDto model)
        {
            T entity = _mapper.Map<TDto, T>(model);
             SetEntityCreatedBaseProperties(entity);
            _unitOfWork.Repository.Add(entity);
            await _unitOfWork.SaveChanges();

            return entity;
        }
        public virtual async Task<List<T>> AddListAsync(List<TDto> model)
        {
            List<T> entities = _mapper.Map<List<TDto>, List<T>>(model);
            _unitOfWork.Repository.AddRange(entities);
            await _unitOfWork.SaveChanges();
            return entities;
        }

        public virtual async Task<T> UpdateAsync(TDto model)
        {
            T entityToUpdate = await _unitOfWork.Repository.GetAsync(model.Id);
            var newEntity = _mapper.Map(model, entityToUpdate);
            SetEntityModifiedBaseProperties(newEntity);
            _unitOfWork.Repository.Update(entityToUpdate, newEntity);
            await _unitOfWork.SaveChanges();
            return newEntity;
        }
        public virtual async Task<T> UpdateModelAsync(T model)
        {
            _unitOfWork.Repository.Update(model, model);
            await _unitOfWork.SaveChanges();
            return model;
        }

        public virtual async Task<string> DeleteAsync(TKey id)
        {

            var entityToDelete = await _unitOfWork.Repository.GetAsync(id);
            if (entityToDelete == null)
            {
                throw new BusinessRuleException("that Jobe is not found.");
            }

            _unitOfWork.Repository.Remove(entityToDelete);
            await _unitOfWork.SaveChanges();

            return "Sucsess";
        }
        public virtual async Task<string> DeleteSoftAsync(TKey id)
        {
            var entityToDelete = await _unitOfWork.Repository.GetAsync(id);
            if (entityToDelete == null)
            {
                throw new BusinessRuleException("that Jobe is not found.");
            }

            SetEntityModifiedBaseProperties(entityToDelete);
            _unitOfWork.Repository.RemoveLogical(entityToDelete);
            await _unitOfWork.SaveChanges();

            return "Sucsess";
        }

        public virtual async Task<TGetDto> GetByIdAsync(TKey id)
        {
            try
            {
                T query = await _unitOfWork.Repository.GetAsync(id);
                return _mapper.Map<T, TGetDto>(query);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleException("Not Found Id");
            }

        }
        public virtual async Task<T> GetModelByIdAsync(TKey id)
        {
            try
            {
                T query = await _unitOfWork.Repository.GetAsync(id);
                return query;
            }
            catch (Exception ex)
            {
                throw new BusinessRuleException("Not Found Id");
            }

        }
        protected void SetEntityCreatedBaseProperties(PrimEntityDto<TKey> entity)
        {
            entity.CreateUserId = UserData.UserId;
            entity.CreateDate = DateTime.Now;

        }

        protected void SetEntityModifiedBaseProperties(PrimEntityDto<TKey> entity)
        {
            entity.ModifyUserId = UserData.UserId;
            entity.ModifyDate = DateTime.Now;

        }



        protected virtual new UserVm UserData
        {
            //get
            //{
            //    model.UserId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "UserId").Value.ToString());
            //    model.Name = _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "Name").Value;

            //    return model;
            //}
            get
            {
                // For testing, return a default user
                return new UserVm
                {
                    UserId = 1, // or any default value
                    Name = "Test User"
                };
            }
        }

    }
}
