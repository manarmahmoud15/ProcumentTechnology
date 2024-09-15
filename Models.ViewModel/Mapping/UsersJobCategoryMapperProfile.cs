using Domain.Entities.Base;
using Library.Helpers.Utilities;
using Domain.Entities.Entity;
using Models.ViewModel.UsersJobCategory;

using user = Domain.Entities.Entity.UsersJobCategory;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void UsersJobCategoryMapperProfile()
        {

            //CreateMap<UsersJobCategoryVm, user>();
            //CreateMap<user, UsersJobCategoryVm>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            //CreateMap<user, ResUsersJobCategoryVm>();

            CreateMap<UsersJobCategoryVm, UsersJob>();
            CreateMap<UsersJob, UsersJobCategoryVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<UsersJob, ResUsersJobCategoryVm>();

        }
    }
}


