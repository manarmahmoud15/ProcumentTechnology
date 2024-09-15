
using Domain.Entities.Entity;
using Domain.Services.Base;
using Models.ViewModel.Category;

namespace Domain.Abstracts.Administration
{
    public interface IUsersRolesService : IBaseApiService<UsersRoles, UsersRolesVm, ResUsersRolesVm, int, int>
    {

    }

}
