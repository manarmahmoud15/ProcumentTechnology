using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel.Price
{
    public class PriceVm : ViewModel, IEntityDto<int>
    {
        public int Id { get; set; }
        public string? Quantity { get; set; }
        public string? price { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Phone { get; set; }
        public string? Detailes { get; set; }
        public string? Email { get; set; }
    }
    public class PriceFilter
    {
    }

}
