using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel.UsersJobStatus
{
    public class UsersJobStatusVm : ViewModel, IEntityDto<int>
    {

        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
    public class UsersJobStatusFilter
    {
    }

}
