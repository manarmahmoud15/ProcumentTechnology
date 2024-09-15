using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Models.ViewModel.Report;
using Domain.Entities.Entity;

using BillModel = Domain.Entities.Entity.Bill;

using Models.ViewModel.Bill;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void ProposalMapperProfile()
        {

            //CreateMap<ProposalVm, ProposalProfileModel>();
            //CreateMap<ProposalProfileModel, ProposalVm>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            //CreateMap<ProposalProfileModel, ResProposalVm>();

            CreateMap<BillVm, BillModel>();
            CreateMap<BillModel, BillVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<BillModel, ResBillVm>();

        }
    }
}


