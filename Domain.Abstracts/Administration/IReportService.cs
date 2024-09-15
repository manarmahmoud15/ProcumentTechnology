
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Models.ViewModel.Category;
using Models.ViewModel.Report;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface IReportService : IBaseApiService<Report, ReportVm, ResReportVm, int, int>
    {

    }

}
