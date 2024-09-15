using Microsoft.AspNetCore.Mvc;
using Domain.Abstracts.Administration;
using Library.Helpers.Utilities;
using Library.Helpers.APIUtilities;
using Ecommerce.WebApi.Abstraction;
using System.ComponentModel.DataAnnotations;
using Poratl.WebApi.Abstraction;
using Models.ViewModel.Base;
using Service.ViewModel.VM;
using Service.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Models.ViewModel.Category;

namespace Poratl.WebApi.Controllers
{
    [AllowAnonymous]
    public class UsersJobsController : ApiControllerBase
    {
        #region Services
        private readonly IUsersJobsService _thisService;
        protected IRepositoryActionResult _repositoryActionResult;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;


        EncryptEngin _EncryptEngin = new EncryptEngin();

        #endregion

        #region Constructor
        public UsersJobsController(IActionResultResponseHandler responseHandler, IRepositoryActionResult repositoryActionResult, IUsersJobsService thisService, IHttpContextAccessor httpContextAccessor, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
          : base(responseHandler)
        {
            _thisService = thisService;
            _repositoryActionResult = repositoryActionResult;
            _hostingEnvironment = hostingEnvironment;

        }
        #endregion

        [AllowAnonymous]
        [HttpPost(Api_Routes.UsersJobs.GetAll)]
        public async Task<IActionResult> GetAll([FromBody] BaseParam<UsersJobsFilter> filter)
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
        [HttpGet(Api_Routes.UsersJobs.Get)]
        public async Task<IActionResult> GetById([Required] int id)
        {
            try
            {
                var result = await _thisService.GetByIdAsync(id);
                return Ok(new SuccessResponse<ResUsersJobsVm>
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

        [HttpPost(Api_Routes.UsersJobs.Create)]
        public async Task<IActionResult> Add([FromBody] UsersJobsVm parameter)
        {
            try
            {
                var data = await _thisService.AddAsync(parameter);

                //Return Created Model With includes 
                var result = await _thisService.GetByIdAsync(data.Id);

                return Ok(new SuccessResponse<ResUsersJobsVm>
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
        [HttpPost(Api_Routes.UsersJobs.Update)]
        public async Task<IActionResult> Update([FromBody] UsersJobsVm parameter)
        {
            try
            {
                var data = await _thisService.UpdateAsync(parameter);

                //Return Updated Model With includes 
                var result = await _thisService.GetByIdAsync(data.Id);

                return Ok(new SuccessResponse<ResUsersJobsVm>
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
        /// Delete 
        /// </summary>
        /// <param name="ids"></param>
        [HttpPost(Api_Routes.UsersJobs.Delete)]
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

        [HttpPost(Api_Routes.UsersJobs.DeleteList)]
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
