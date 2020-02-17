namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> x)
        {
            x.HasMany(x => x.Foods).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.Restrict);
            x.HasMany(x => x.Toys).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
