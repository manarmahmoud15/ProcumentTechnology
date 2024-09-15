using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Abstracts.Administration;
using Library.Helpers.Utilities;
using Library.Helpers.APIUtilities;
using Ecommerce.WebApi.Abstraction;
using System.ComponentModel.DataAnnotations;
using Poratl.WebApi.Abstraction;
using Models.ViewModel.Base;
using Microsoft.AspNetCore.Hosting;
using Service.ViewModel.VM;
using Service.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Models.ViewModel.Category;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System;
using Domain.Entities.Entity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Poratl.WebApi.Controllers
{
    [AllowAnonymous]
    public class UsersController : ApiControllerBase
    {
        #region Services
        private readonly IUsersService _thisService;
        private readonly IUsersRolesService _IUsersRolesService;

        protected IRepositoryActionResult _repositoryActionResult;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _config;
        protected readonly IMapper _mapper;
        //private readonly ISearchService _thisServiceSearch;

        EncryptEngin _EncryptEngin = new EncryptEngin();

        #endregion

        #region Constructor
        public UsersController(IActionResultResponseHandler responseHandler, IRepositoryActionResult repositoryActionResult, IUsersService thisService, IUsersRolesService IUsersRolesService, IHttpContextAccessor httpContextAccessor, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IConfiguration config,IMapper mapper = null)//, ISearchService thisServiceSearch
          : base(responseHandler)
        {
            _thisService = thisService;
            _repositoryActionResult = repositoryActionResult;
            _hostingEnvironment = hostingEnvironment;
            _config = config;
            _IUsersRolesService = IUsersRolesService;
            _mapper = mapper;
           // _thisServiceSearch = thisServiceSearch;
        }
        #endregion

        [AllowAnonymous]
        [HttpPost(Api_Routes.Users.GetAll)]
        public async Task<IActionResult> GetAll([FromBody] BaseParam<UsersFilter> filter)
        {
            try
            {
                var result = await _thisService.FindPagedAsync(a => a.Id > 0,
                PageSize: filter.PageSize,
                PageNumber: filter.PageNumber,
                orderByCriteria: filter.OrderByValue)   ;
           
                return Ok(new SuccessResponse<DataPaging>
                {
                    Code = 200,
                    Data = result
                });

            }
            catch (BusinessRuleException ex)
            {

                return BadRequest(new FailureResponse
                {
                    Code = 404,
                    Error = ex.Message
                });
            }
        }
        [AllowAnonymous]
        [HttpGet(Api_Routes.Users.Get)]
        public async Task<IActionResult> GetById([Required] int id)
        {
            try
            {
                var result = await _thisService.GetByIdAsync(id);
                return Ok(new SuccessResponse<ResUsersVm>
                {
                    Code = 200,
                    Data = result
                });
            }
            catch (BusinessRuleException ex)
            {

                return BadRequest(new FailureResponse
                {
                    Code = 404,
                    Error = ex.Message
                });
            }
           
        }

        [HttpPost(Api_Routes.Users.Create)]
        public async Task<IActionResult> Add([FromBody] UsersVm parameter)
        {
            try
            {
                var data = await _thisService.AddAsync(parameter);

                //Return Created Model With includes 
                var result = await _thisService.GetByIdAsync(data.Id);

                return Ok(new SuccessResponse<ResUsersVm>
                {
                    Code = 200,
                    Data = result
                });
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(new FailureResponse
                {
                    Code = 404,
                    Error = ex.Message
                });
            }

        }

        /// <summary>
        /// Update Activity
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        //[ClaimRequirement("Activity", "Update")]
        [HttpPost(Api_Routes.Users.Update)]
        public async Task<IActionResult> Update([FromBody] UsersVm parameter)
        {
            try
            {
                var data = await _thisService.UpdateAsync(parameter);

                //Return Updated Model With includes 
                var result = await _thisService.GetByIdAsync(data.Id);

                return Ok(new SuccessResponse<ResUsersVm>
                {
                    Code = 200,
                    Data = result
                });
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(new FailureResponse
                {
                    Code = 404,
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [HttpPost(Api_Routes.Users.Login)]
        public async Task<IActionResult> Login([FromBody]LoginParamter obj)
        {
                try
                {
                //model.Password = obj.Password.Trim();//_EncryptEngin.Encrypt(obj.Username.Trim().ToLower() + "♪" + obj.Password.Trim(), "icat2056913!", true);
                obj.Password = obj.Password;//_EncryptEngin.Encrypt(obj.UserName.Trim().ToLower() + "♪" + obj.Password.Trim(), "icat2056913!", true);
                var user = await _thisService.Login(obj);
                if (user == null)
                {
                    return BadRequest(new FailureResponse
                    {
                        Code = 404,
                        Error = "user not found"
                    });
                }
                else
                {
                    string UpdateLastLogin = null; //_thisServiceSearch.UpdateUserLastLogin(user.Id.ToString());

                    if (user.LastName == null)
                        user.LastName = "";

                    //  var claims = new[] {
                    //              new Claim("UserId",user.Id.ToString()),
                    //              new Claim("NameEn",user.FirstName.ToString()),
                    //              new Claim("RoleId",user.RoleId.ToString()),
                    //              new Claim("SideId",user.SideId.ToString()),


                    //              new Claim("NameAr",user.LastName.ToString()),
                    //              //new Claim("Company",user.Company.ToString()),
                    //              //new Claim("Branch",user.Branch.ToString()),
                    //              new Claim("Name",GetLang() ==Language.Arabic ? user.FirstName.ToString()+" "+user.LastName??"": user.FirstName.ToString()+" "+user.LastName??""),
                    //          }; 
                    //  var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]));
                    //  var expiryInHours = DateTime.Now.AddHours(Convert.ToDouble(_config["Jwt:ExpiryInHours"]));
                    //  var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    //  var token = new JwtSecurityToken(
                    //      issuer: _config["Jwt:Site"],
                    //      audience: _config["Jwt:Site"],
                    //      expires: expiryInHours,
                    //      signingCredentials: credentials,
                    //      claims: claims);
                    //var tokenRes = new JwtSecurityTokenHandler().WriteToken(token);

                    var UserData = await _thisService.FindPagedAsync(a => a.Id > 0 && (user.Id == a.Id),
                                  PageSize: 1000,
                                  PageNumber: 1,
                                  orderByCriteria: null);//.ThenInclude(c => c.RolesPages).ThenInclude(c => c.Page));

                    var res2 = _mapper.Map<IEnumerable<ResUsersVm>>(UserData.Result);

                    LoginResponse res= new LoginResponse();
                    res.FirstName = user.FirstName;
                    res.LastName = user.LastName;
                    res.UserId = user.Id;
                    //res.Token = tokenRes;
                    //res.RoleId = user.RoleId;
                  //  res.SideId = user.SideId;
                    //res.SideId = res2.;

 


                    foreach (var userlogin in res2)
                    {
                        //res.Role = userlogin.Role.Title;
                        //res.Side = userlogin.Side.NameEn;
                        // res.RolesPages = new List<ResRolesPagesVm>();


                        //foreach (var userloginRole in userlogin.Role.RolesPages)
                        //{
                        //    ResRolesPagesVm objRole = new ResRolesPagesVm();
                        //    ResPagesVm objPage = new ResPagesVm();

                        //    objRole.Id = userloginRole.Id;
                        //    objRole.RoleId = userloginRole.RoleId;
                        //    objRole.PageId = userloginRole.PageId;
                        //    objRole.ViewAction = userloginRole.ViewAction;
                        //    objRole.InsertAction = userloginRole.InsertAction;
                        //    objRole.DeleteAction = userloginRole.DeleteAction;
                        //    objRole.UpdateAction = userloginRole.UpdateAction;
                        //    objRole.FilterAction = userloginRole.FilterAction;
                        //    objRole.PrintAction = userloginRole.PrintAction;

                        //    objPage.Title = userloginRole.Page.Title;
                        //    objPage.TitleAr = userloginRole.Page.TitleAr;
                        //    objPage.Id = userloginRole.Page.Id;

                        //    objRole.Page = objPage;

                        //    //res.RolesPages.Add(objRole);




                        //}

                    }

                    var claims = new[] {
                                new Claim("UserId",user.Id.ToString()),
                                new Claim("NameEn",user.FirstName.ToString()),
                                new Claim("RoleId",user.RoleId.ToString()),
                                //new Claim("SideId",user.SideId.ToString()),
                              //  new Claim("RolesPages",res.RolesPages.ToString()),


                                new Claim("NameAr",user.LastName.ToString()),
                                //new Claim("Company",user.Company.ToString()),
                                //new Claim("Branch",user.Branch.ToString()),
                                new Claim("Name",GetLang() ==Language.Arabic ? user.FirstName.ToString()+" "+user.LastName??"": user.FirstName.ToString()+" "+user.LastName??""),
                            };
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]));
                    var expiryInHours = DateTime.Now.AddHours(Convert.ToDouble(_config["Jwt:ExpiryInHours"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: _config["Jwt:Site"],
                        audience: _config["Jwt:Site"],
                        expires: expiryInHours,
                        signingCredentials: credentials,
                        claims: claims);
                    var tokenRes = new JwtSecurityTokenHandler().WriteToken(token);

                    res.Token = tokenRes;


                    return Ok(new SuccessResponse<LoginResponse>
                    {
                        Code = 200,
                        Data = res
                    });
                }
                }
                catch (Exception e)
                {
                return BadRequest(new FailureResponse
                {
                    Code = 404,
                    Error = e.Message
                });
            }
            }
        

        //[HttpGet(Api_Routes.Users.Block)]
        //public async Task<IActionResult> Block([Required] int id)
        //{
        //    try
        //    {
        //        var result = await _thisService.DeleteSoftAsync(id);
        //        return Ok(new SuccessResponse<string>
        //        {
        //            Code = 200,
        //            Data = result
        //        });
        //    }
        //    catch (BusinessRuleException ex)
        //    {

        //        return BadRequest(new FailureResponse
        //        {
        //            Code = 404,
        //            Error = ex.Message
        //        });
        //    }
        //}

        /// <summary>
        /// Delete Activities
        /// </summary>
        /// <param name="ids"></param>
        [HttpPost(Api_Routes.Users.Delete)]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                var result = await _thisService.DeleteAsync(id);
                return Ok(new SuccessResponse<string>
                {
                    Code = 200,
                    Data = result
                });
            }
            catch (BusinessRuleException ex)
            {

                return BadRequest(new FailureResponse
                {
                    Code = 404,
                    Error = ex.Message
                });
            }
        }

        [HttpPost(Api_Routes.Users.DeleteList)]
        public async Task<IActionResult> DeleteList([Required] List<int> ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    await _thisService.DeleteAsync(id);
                }
                return Ok(new SuccessResponse<string>
                {
                    Code = 200,
                    Data = "Sucsess"
                });
            }
            catch (BusinessRuleException ex)
            {

                return BadRequest(new FailureResponse
                {
                    Code = 404,
                    Error = ex.Message
                });
            }

        }


    }
}
