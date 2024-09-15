using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Domain.Entities.Entity;
using UserJobStatusModel = Domain.Entities.Entity.UsersJobStatus;
using Models.ViewModel.UsersJobStatus;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void UserJobStatusMapperProfile()
        {

            //CreateMap<UsersJobStatusVm, UserJobStatusModel>();
            //CreateMap<UserJobStatusModel, UsersJobStatusVm>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            //CreateMap<UserJobStatusModel, ResUsersJobStatusVm>();

            //CreateMap<UsersJobStatusVm, UsersJob>();
            //CreateMap<UsersJob, UsersJobStatusVm>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            //CreateMap<UsersJob, ResUsersJobStatusVm>();



        }
    }
}


