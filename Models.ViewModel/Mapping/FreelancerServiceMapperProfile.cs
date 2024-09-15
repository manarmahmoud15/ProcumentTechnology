using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Domain.Entities.Entity;

using FreelancerServiceModel = Domain.Entities.Entity.FreelancerService;
using Models.ViewModel.FreelancerService;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void FreelancerServiceMapperProfile()
        {

            //CreateMap<FreelancerServiceVm, FreelancerServiceModel>();
            //CreateMap<FreelancerServiceModel, FreelancerServiceVm>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            //CreateMap<FreelancerServiceModel, ResFreelancerServiceVm>();

            CreateMap<FreelancerServiceVm, UsersJob>();
            CreateMap<UsersJob, FreelancerServiceVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<UsersJob, ResFreelancerServiceVm>();

        }
    }
}


