using AutoMapper;
using Domain.Abstracts.Administration;
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Library.Helpers.UnitOfWork;
using Models.ViewModel.Category;
using Models.ViewModel.Product;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Administration
{
    public class ProductService : BaseApiService<Products, ProductVm, ResProductVm, int,int>, IProductsService
    {
        public ProductService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<Products, int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, IMapper _mapper)
             : base(repositoryActionResult, unitOfWork, httpContextAccessor, _mapper)
        {

        }
    }
}
