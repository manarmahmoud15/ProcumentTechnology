using Domain.Entities.Base;
using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModel.Category
{
    public class ResUsersVm : ViewModel, IEntityDto<int>
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public int SideId { get; set; }
        public int RoleId { get; set; }



    }
    public class LoginParamter
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class LoginResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public int SideId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string Side { get; set; }
      //  public List<ResRolesPagesVm> RolesPages { get; set; }


    }
}
