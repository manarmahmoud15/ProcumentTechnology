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
using Models.ViewModel.Communications;
using Domain.Services.Administration;

namespace Poratl.WebApi.Controllers
{
    [AllowAnonymous]
    public class CommunicationsController : ApiControllerBase
    {
        #region Services
        private readonly ICommunicationsService _thisService;
        protected IRepositoryActionResult _repositoryActionResult;
        private readonly IFileService fileService;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;


        EncryptEngin _EncryptEngin = new EncryptEngin();

        #endregion

        #region Constructor
        public CommunicationsController(IActionResultResponseHandler responseHandler, 
            IRepositoryActionResult repositoryActionResult, ICommunicationsService thisService, 
            IHttpContextAccessor httpContextAccessor, 
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
             IFileService fileService )
          : base(responseHandler)
        {
            _thisService = thisService;
            _repositoryActionResult = repositoryActionResult;
            _hostingEnvironment = hostingEnvironment;
            this.fileService = fileService;

        }
        #endregion

        [AllowAnonymous]
        [HttpPost(Api_Routes.Communications.GetAll)]
        public async Task<IActionResult> GetAll([FromBody] BaseParam<CommunicationsFilter> filter)
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
        [HttpGet(Api_Routes.Communications.Get)]
        public async Task<IActionResult> GetById([Required] int id)
        {
            try
            {
                var result = await _thisService.GetByIdAsync(id);
                return Ok(new SuccessResponse<ResCommunicationsVm>
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

        [HttpPost(Api_Routes.Communications.Create)]
        public async Task<IActionResult> Add([FromForm] CommunicationsVm parameter)
        {
            try
            {
                if (parameter.Images != null)
                {
                    var fileResult = fileService.SaveFile(parameter.Images);
                    if (fileResult.Item1 == 1)
                    {
                        parameter.ImagesPath = fileResult.Item2;
                    }
                    else
                    {
                        return BadRequest(new FailureResponse
                        {
                            Code = 400,
                            Error = "Invalid file format. Only .pdf, .jpg, .png, .jpeg are allowed."
                        });
                    }
                }
                if (parameter.LogoImg != null)
                {
                    var fileResult = fileService.SaveFile(parameter.LogoImg);
                    if (fileResult.Item1 == 1)
                    {
                        parameter.LogoImgPath = fileResult.Item2;
                    }
                    else
                    {
                        return BadRequest(new FailureResponse
                        {
                            Code = 400,
                            Error = "Invalid file format. Only .pdf, .jpg, .png, .jpeg are allowed."
                        });
                    }
                }
                var data = await _thisService.AddAsync(parameter);

                //Return Created Model With includes 
                var result = await _thisService.GetByIdAsync(data.Id);

                return Ok(new SuccessResponse<ResCommunicationsVm>
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
        [HttpPost(Api_Routes.Communications.Update)]
        public async Task<IActionResult> Update([FromBody] CommunicationsVm parameter)
        {
            try
            {
                var data = await _thisService.UpdateAsync(parameter);

                //Return Updated Model With includes 
                var result = await _thisService.GetByIdAsync(data.Id);

                return Ok(new SuccessResponse<ResCommunicationsVm>
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
        [HttpPost(Api_Routes.Communications.Delete)]
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

        [HttpPost(Api_Routes.Communications.DeleteList)]
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
