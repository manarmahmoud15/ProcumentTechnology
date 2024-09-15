using Medianesta.DataLayer.Base;

#nullable disable

namespace Domain.Entities.Entity
{
    public partial class UsersRoles : PrimEntityDto<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }




    }
}
