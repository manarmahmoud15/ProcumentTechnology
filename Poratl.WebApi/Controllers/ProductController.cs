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
using Models.ViewModel.Product;
using Domain.Services.Administration;

namespace Poratl.WebApi.Controllers
{
    [AllowAnonymous]
    public class ProductController : ApiControllerBase
    {
        #region Services
        private readonly IProductsService _thisService;
        private readonly IFileService fileService;
        protected IRepositoryActionResult _repositoryActionResult;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;


        EncryptEngin _EncryptEngin = new EncryptEngin();

        #endregion

        #region Constructor
        public ProductController(IActionResultResponseHandler responseHandler, 
            IRepositoryActionResult repositoryActionResult,
            IProductsService thisService, IHttpContextAccessor httpContextAccessor,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment
            , IFileService fileService)
          : base(responseHandler)
        {
            _thisService = thisService;
            _repositoryActionResult = repositoryActionResult;
            _hostingEnvironment = hostingEnvironment;
            this.fileService = fileService;
        }
        #endregion

        [AllowAnonymous]
        [HttpPost(Api_Routes.Product.GetAll)]
        public async Task<IActionResult> GetAll([FromBody] BaseParam<ProductFilter> filter)
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
        [HttpGet(Api_Routes.Product.Get)]
        public async Task<IActionResult> GetById([Required] int id)
        {
            try
            {
                var result = await _thisService.GetByIdAsync(id);
                return Ok(new SuccessResponse<ResProductVm>
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

        [HttpPost(Api_Routes.Product.Create)]
        public async Task<IActionResult> Add([FromForm] ProductVm parameter)
        {
            try
            {
                if (parameter.Photo != null)
                {
                    var fileResult = fileService.SaveFile(parameter.Photo);
                    if (fileResult.Item1 == 1)
                    {
                        parameter.PhotoPath = fileResult.Item2; 
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
                var result = await _thisService.GetByIdAsync(data.Id);
                return Ok(new SuccessResponse<ResProductVm>
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
        [HttpPost(Api_Routes.Product.Update)]
        public async Task<IActionResult> Update([FromBody] ProductVm parameter)
        {
            try
            {
                var data = await _thisService.UpdateAsync(parameter);

                //Return Updated Model With includes 
                var result = await _thisService.GetByIdAsync(data.Id);

                return Ok(new SuccessResponse<ResProductVm>
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
        [HttpPost(Api_Routes.Product.Delete)]
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

        [HttpPost(Api_Routes.Product.DeleteList)]
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
