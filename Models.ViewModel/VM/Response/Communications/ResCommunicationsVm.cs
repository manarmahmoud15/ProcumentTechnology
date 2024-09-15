using Domain.Entities.Base;
using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.ViewModel.Communications
{
    public class ResCommunicationsVm : ViewModel, IEntityDto<int>
    {
        public int Id { get; set; }
        public IFormFile? Images { get; set; }
        public string? ImagesPath { get; set; }
        public IFormFile? LogoImg { get; set; } // image 
        public string? LogoImgPath { get; set; }
        public string? Price { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? Details { get; set; }
    }

}
