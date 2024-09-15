using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;
using Library.Helpers.APIUtilities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Models.ViewModel.Category;

namespace Ecommerce.WebApi.Abstraction
{
    /// <inheritdoc />
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [Authorize]
    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// Token Business
        /// </summary>
        /// <summary>
        /// Response Handler
        /// </summary>
        protected readonly IActionResultResponseHandler ResponseHandler;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserVm model;
        public ApiControllerBase(IHttpContextAccessor httpContextAccessor, IActionResultResponseHandler responseHandler,
                                 IConfiguration configuration = null)
        {
            _httpContextAccessor = httpContextAccessor;
            ResponseHandler = responseHandler;
            _configuration = configuration;
            model = new UserVm();

        }
        protected string UserId =>  User.FindFirst(ClaimTypes.NameIdentifier)?.Value ;

        public ApiControllerBase(IActionResultResponseHandler responseHandler ,
                                 IConfiguration configuration = null)
        {
            ResponseHandler = responseHandler;
            _configuration = configuration;
            //if(GetLang() == Language.Arabic)
            //{
            //    ResourcesReader.IsArabic = true
            //}
        }
        [NonAction]
        public Language GetLang()
        {
            StringValues langs;
            Request.Headers.TryGetValue("lang", out langs);
            var lang = langs.FirstOrDefault();
            return string.IsNullOrEmpty(lang) ? Language.English : lang == "en" ? Language.English : Language.Arabic;
        }

        [NonAction]
        public string GetDomainPath()
        {
            var x = _configuration["SystemKeys:Protocal"];
            return _configuration["SystemKeys:Protocal"] + Request.HttpContext.Request.Host.Host + ":" + Request.HttpContext.Request.Host.Port + "/";
        }
        protected virtual UserVm UserData
        {
            get
            {
                model.UserId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "UserId").Value.ToString());
                model.RoleId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "RoleId").Value.ToString());
              //  model.SideId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "SideId").Value.ToString());

                model.Name = _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "Name").Value;

                return model;
            }
        }
    }
}
