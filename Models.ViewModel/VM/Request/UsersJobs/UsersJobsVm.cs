using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel.Category
{
    public class UsersJobsVm : ViewModel, IEntityDto<int>
    {
        public string JobName { get; set; }
    }
    public class UsersJobsFilter
    {
        public long FK_Company { get; set; }
    }

}
