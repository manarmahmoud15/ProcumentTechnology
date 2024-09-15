using Medianesta.DataLayer.Base;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domain.Entities.Entity
{
    public partial class User : PrimEntityDto<int>
    {

        //public User()
        //{
        //    UsersRoles = new HashSet<UsersRoles>();

        //}
        //public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? ProfilePicture  { get; set; }
        public int UserType  { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Job { get; set; }


        public bool? IsVerified  { get; set; }
        public DateTime? DateJoined { get; set; }
        public DateTime? LastLogin { get; set; }

        [Required]
        public int RoleId { get; set; }



    }
}
