namespace MyCoolCarSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCoolCarSystem.Data.Models;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> x)
        {
            x.HasIndex(x => x.Vin).IsUnique();
            x.HasOne(x => x.Model).WithMany(x => x.Cars).HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
