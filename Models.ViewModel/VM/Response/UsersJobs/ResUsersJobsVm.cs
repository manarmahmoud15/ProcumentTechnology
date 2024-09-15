using Domain.Entities.Base;
using Library.Helpers.APIUtilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModel.Category
{
    public class ResUsersJobsVm : ViewModel, IEntityDto<int>
    {
        public int JobId { get; set; }
        public string JobName { get; set; }

    }
}
