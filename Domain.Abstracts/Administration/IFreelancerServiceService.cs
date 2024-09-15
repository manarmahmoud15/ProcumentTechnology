
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Models.ViewModel.Category;
using Models.ViewModel.FreelancerService;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface IFreelancerServiceService : IBaseApiService<UsersJob, FreelancerServiceVm, ResFreelancerServiceVm, int, int>
    {

    }

}
