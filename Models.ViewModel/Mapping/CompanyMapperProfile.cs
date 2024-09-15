using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Domain.Entities.Entity;
using companyModel = Domain.Entities.Entity.Company;
using Models.ViewModel.Company;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void CompanyMapperProfile()
        {

            CreateMap<CompanyVm, companyModel>();
            CreateMap<companyModel, CompanyVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<companyModel, ResCompanyVm>();

        }
    }
}


