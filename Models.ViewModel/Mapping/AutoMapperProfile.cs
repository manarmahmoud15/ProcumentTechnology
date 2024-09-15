
using AutoMapper;
using Library.Helpers.APIUtilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Linq;
namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        private  HttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        public Language GetUserLangId()
        {
            StringValues langs;
            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("lang", out langs);
            var lang = langs.FirstOrDefault();
            return string.IsNullOrEmpty(lang) ? Language.English : lang == "en" ? Language.English : Language.Arabic;
        }

        public AutoMapperProfile()
        {
            UsersMappingProfile();
            UsersRolesMappingProfile();
            UsersJobsMappingProfile();
            ReportMappingProfile();
            PriceMapperProfile();
            ElectronicMapperProfile();
            UsersJobCategoryMapperProfile();
            ProductMapperProfile();
            FreelancerServiceMapperProfile();
            CompanyMapperProfile();
            ProposalMapperProfile();
            TransactionMapperProfile();
            UsersJobsMappingProfile();
            UsersJobsMappingProfile();


        }
    }
}
