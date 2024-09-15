using Medianesta.DataLayer.Base;


namespace Domain.Entities.Entity
{
    public partial class UsersJobStatus : PrimEntityDto<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

    }
}
