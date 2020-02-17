namespace MyCoolCarSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCoolCarSystem.Data.Models;

    class CarPuchaseConfiguration : IEntityTypeConfiguration<CarPurchase>
    {
        public void Configure(EntityTypeBuilder<CarPurchase> x)
        {
            x.HasKey(x => new { x.CustomerId, x.CarId });
            x.HasOne(x => x.Customer).WithMany(x => x.Purchases).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
            x.HasOne(x => x.Car).WithMany(x => x.Owners).HasForeignKey(x => x.CarId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
