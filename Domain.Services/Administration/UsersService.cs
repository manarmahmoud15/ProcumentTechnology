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
    public class UsersService : BaseApiService<User, UsersVm, ResUsersVm, int,int>, IUsersService
    {
        public UsersService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<User, int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, IMapper _mapper)
             : base(repositoryActionResult, unitOfWork, httpContextAccessor, _mapper)
        {

        }



        public async Task<User> Login(LoginParamter paramter)
        {

            var user =await _unitOfWork.Repository.FirstOrDefaultAsync(q=>q.UserName == paramter.UserName && q.Password == paramter.Password);
            //if(user !=null)
            //{
            //    user.Role=
            //}
            return user;
        }
    }
}
