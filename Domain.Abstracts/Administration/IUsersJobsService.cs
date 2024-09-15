
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Models.ViewModel.Category;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface IUsersJobsService : IBaseApiService<UsersJob, UsersJobsVm, ResUsersJobsVm, int, int>
    {

    }

}
