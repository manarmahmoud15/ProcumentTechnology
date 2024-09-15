using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using System;

namespace Models.ViewModel.Category
{
    public class ResUsersRolesVm : ViewModel, IEntityDto<int>
    {

        public int UserId { get; set; }
        public int RoleId { get; set; }

        public  User User { get; set; }


    }
}
