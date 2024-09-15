
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Models.ViewModel.Category;
using Models.ViewModel.Bill;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface IBillService : IBaseApiService<Bill, BillVm, ResBillVm, int, int>
    {

    }

}
