using Domain.Entities.Base;
using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModel.Company

{
    public class ResCompanyVm : ViewModel, IEntityDto<int>
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }

}
