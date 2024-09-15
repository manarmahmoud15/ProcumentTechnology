﻿using Domain.Entities.Base;
using Domain.Entities.Entity;
using Library.Helpers.Utilities;
using Models.ViewModel.Category;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void UsersMappingProfile()
        {
          
            CreateMap<UsersVm, User>();
            CreateMap<User, UsersVm>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
                //.ForMember(dest => dest.FK_Company_Name, opt => opt.MapFrom(src => ResourcesReader.IsArabic ? src.Company == null ? "" : src.Company.NameAr : src.Company == null ? "" : src.Company.NameEn))
              

            CreateMap<User, ResUsersVm>();
        }
    }           
}               
                
                