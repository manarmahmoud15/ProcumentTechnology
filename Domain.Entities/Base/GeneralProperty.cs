using Domain.Entities.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medianesta.DataLayer.Base
{
    public class GeneralProperty 
    {
        public int? CreateUserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int? ModifyUserId { get; set; }
        public DateTime? ModifyDate { get; set; }

        //[ForeignKey(nameof(CreateUserId))]
        //public virtual User CreatedUser { get; set; }

        //[ForeignKey(nameof(ModifyUserId))]
        //public virtual User ModifyedUser { get; set; }
    }

    //public class GeneralHistoryIntProperty
    //{
    //    public int CreateUserId { get; set; }
    //    public DateTime CreateDate { get; set; } = DateTime.Now;
    //    [ForeignKey("CreateUserId")]
    //    public virtual TBL_User User { get; set; }
    //}
    public class PrimEntityDto<TPrimaryKey> : GeneralProperty
    {
        [Key]
      public  TPrimaryKey Id { get; set; }
        public bool IsBlock { get; set; } = false;
    }
    public class GeneralTable<TKey> : GeneralProperty
    {
        [Key]
        public TKey Id { get; set; }
        public bool IsBlock { get; set; } = false;
    }
    public class GeneralLookupProperty: GeneralProperty
    {
        [Key]
        public int Id { get; set; }
       
        public bool IsBlock { get; set; } = false;
    }
    public class LookUpEntity<TKey>
    {
        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        public string NameEn { get; set; }
        [StringLength(256)]
        public string NameAr { get; set; }
        public bool IsBlock { get; set; } = false;

    }

    public class LookUpEntityWithNoIdentity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(256)]
        public string NameEn { get; set; }
        [StringLength(256)]
        public string NameAr { get; set; }
    }


}
