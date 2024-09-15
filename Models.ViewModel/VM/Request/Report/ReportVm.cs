﻿using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel.Report
{
    public class ReportVm : ViewModel, IEntityDto<int>
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Product { get; set; }
        public string? CompanyName { get; set; }
        public string? Price { get; set; }
        public string? Quantity { get; set; }
        public string? TotalPrice { get; set; }
        public string? Convenant { get; set; }//    العهده 
        public string? RestCovenant { get; set; }

    }
    public class ReportFilter
    {

    }
}
