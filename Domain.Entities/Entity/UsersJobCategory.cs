using Medianesta.DataLayer.Base;


namespace Domain.Entities.Entity
{
    public partial class UsersJobCategory : PrimEntityDto<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

    }
}
