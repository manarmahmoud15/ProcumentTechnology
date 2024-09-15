using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Domain.Entities.Entity;
using Models.ViewModel.Category;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void UsersJobMapperProfile()
        {

            CreateMap<UsersJobsVm, UsersJob>();
            CreateMap<UsersJob, UsersJobsVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<UsersJob, ResUsersJobsVm>();

        }
    }
}


