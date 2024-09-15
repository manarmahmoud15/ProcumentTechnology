using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModel.Category
{
    public class UsersVm : ViewModel, IEntityDto<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public int RoleId { get; set; }
    }
    public class UsersFilter
    {
    }
    public class UserVm
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }


        public string Name { get; set; }
    }
}
