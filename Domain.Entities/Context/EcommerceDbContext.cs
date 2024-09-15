using Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Context
{
    public partial class EcommerceDbContext : DbContext//IdentityDbContext
    {
        private readonly ISeedData _dataInitializer;

        public EcommerceDbContext()
        {

        }

        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options, ISeedData dataInitializer)
            : base(options)
        {
            _dataInitializer = dataInitializer;
        }


      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed
            //modelBuilder.Entity<TBL_Company>().HasData(_dataInitializer.ReturnCompaniesList());
           #endregion
            base.OnModelCreating(modelBuilder);

           // modelBuilder.Entity<TBL_ProductsRelated>()
           //.HasOne(p => p.Products)
           //.WithMany(b => b.ProductsRelated)
           //.HasForeignKey(p => p.FK_Products);
        }

    }
}
