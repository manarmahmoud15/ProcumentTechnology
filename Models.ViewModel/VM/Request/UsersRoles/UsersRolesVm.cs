using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel.Category
{
    public class UsersRolesVm : ViewModel, IEntityDto<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

    }
    public class UsersRolesFilter
    {
        public long UserId { get; set; }
    }

}
