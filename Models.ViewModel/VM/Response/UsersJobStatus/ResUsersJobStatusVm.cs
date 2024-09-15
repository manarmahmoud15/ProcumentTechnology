using Domain.Entities.Base;
using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModel.UsersJobStatus
{
    public class ResUsersJobStatusVm : ViewModel, IEntityDto<int>
    {


        public string NameAr { get; set; }
        public string NameEn { get; set; }



    }

}
