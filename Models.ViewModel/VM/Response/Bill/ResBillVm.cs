using Domain.Entities.Base;
using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.ViewModel.Bill
{
    public class ResBillVm : ViewModel, IEntityDto<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CompanyName { get; set; }
        public string Details { get; set; }
        public string BillNumber { get; set; }
        public string? BillFile { get; set; }
        public IFormFile? BillFilePath { get; set; } // upload image and PDF
    }

}
