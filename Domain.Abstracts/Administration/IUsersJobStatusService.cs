
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Models.ViewModel.Category;
using Models.ViewModel.UsersJobStatus;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface IUsersJobStatusService : IBaseApiService<UsersJob, UsersJobStatusVm, ResUsersJobStatusVm, int, int>
    {

    }

}
