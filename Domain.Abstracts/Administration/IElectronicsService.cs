
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Models.ViewModel.Category;
using Models.ViewModel.Electronics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface IElectronicsService : IBaseApiService<Electronics, ElectronicsVm, ResElectronicsVm, int, int>
    {

    }

}
