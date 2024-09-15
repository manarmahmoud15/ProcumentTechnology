
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Models.ViewModel.Category;
using Models.ViewModel.UsersJobCategory;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface IUsersJobCategoryService : IBaseApiService<UsersJob, UsersJobCategoryVm, ResUsersJobCategoryVm, int, int>
    {

    }

}
