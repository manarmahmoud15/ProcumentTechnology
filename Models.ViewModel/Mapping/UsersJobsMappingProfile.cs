using Domain.Entities.Base;
using User = Domain.Entities.Entity.UsersJobCategory;
using Library.Helpers.Utilities;
using Models.ViewModel.UsersJobCategory;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void UsersJobsMappingProfile()
        {
          
            CreateMap<UsersJobCategoryVm, User>();
            CreateMap<User, UsersJobCategoryVm>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
                //.ForMember(dest => dest.FK_Company_Name, opt => opt.MapFrom(src => ResourcesReader.IsArabic ? src.Company == null ? "" : src.Company.NameAr : src.Company == null ? "" : src.Company.NameEn))
              

            CreateMap<User, ResUsersJobCategoryVm>();
        }
    }           
}               
                
                