
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Models.ViewModel.Category;
using Models.ViewModel.Company;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface ICompanyService : IBaseApiService<Company, CompanyVm, ResCompanyVm, int, int>
    {

    }

}
