using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel.Company
{
    public class CompanyVm : ViewModel, IEntityDto<int>
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
    public class CompanyFilter
    {
    }

}
