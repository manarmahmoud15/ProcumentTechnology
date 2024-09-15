using Domain.Entities.Base;
using ReportModel = Domain.Entities.Entity.Report;
using Library.Helpers.Utilities;
using Models.ViewModel.Report;
using Domain.Entities.Entity;


namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void ReportMappingProfile()
        {

            CreateMap<ReportVm, ReportModel>();
            CreateMap<ReportModel, ReportVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<ReportModel, ResReportVm>();

        }
    }
}


