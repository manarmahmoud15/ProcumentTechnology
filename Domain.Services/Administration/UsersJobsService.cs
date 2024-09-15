using AutoMapper;
using Domain.Abstracts.Administration;
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Library.Helpers.UnitOfWork;
using Models.ViewModel.Category;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Administration
{
    public class UsersJobsService : BaseApiService<UsersJob, UsersJobsVm, ResUsersJobsVm, int,int>, IUsersJobsService
    {
        public UsersJobsService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<UsersJob, int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, IMapper _mapper)
             : base(repositoryActionResult, unitOfWork, httpContextAccessor, _mapper)
        {

        }
    }
}
