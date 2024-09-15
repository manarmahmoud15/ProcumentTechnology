using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel.Electronics
{
    public class ElectronicsVm : ViewModel, IEntityDto<int>
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDetails { get; set; }
        public string? ProductColor { get; set; }
        public string? ProductSize { get; set; }
        public string? ProductPrice { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
    public class ElectronicsFilter
    {
    }

}
