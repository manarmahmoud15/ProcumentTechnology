using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Poratl.ApiTask
{


    /// <inheritdoc />

    public class ClaimRequirementIcAttribute : TypeFilterAttribute
    {


        /// <inheritdoc />
        public ClaimRequirementIcAttribute(int claimType, int claimValue)
            : base(typeof(ClaimRequirementIcFilter))
        {
            Arguments = new object[] { new Claim(claimType.ToString(), claimValue.ToString()) };

        }
    }
    /// <inheritdoc />

    public class ClaimRequirementIcFilter : IAuthorizationFilter
    {

        readonly Claim _claim;

        public ClaimRequirementIcFilter(Claim claim)
        {
            _claim = claim;
        }



        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var userId = context.HttpContext.User.Claims.First(t => t.Type == "UserId").Value;
            var userType = context.HttpContext.User.Claims.First(t => t.Type == "RoleId").Value;
            var RolesPages = context.HttpContext.User.Claims.First(t => t.Type == "RolesPages").Value.ToList();




        }
    }


}
