using AutoMapper;
using Domain.Abstracts.Administration;
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Library.Helpers.UnitOfWork;
using Models.ViewModel.Category;

namespace Domain.Services.Administration
{
    public class UsersRolesService : BaseApiService<UsersRoles, UsersRolesVm, ResUsersRolesVm, int,int>, IUsersRolesService
    {
        public UsersRolesService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<UsersRoles, int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, IMapper _mapper)
             : base(repositoryActionResult, unitOfWork, httpContextAccessor, _mapper)
        {

        }
    }
}
