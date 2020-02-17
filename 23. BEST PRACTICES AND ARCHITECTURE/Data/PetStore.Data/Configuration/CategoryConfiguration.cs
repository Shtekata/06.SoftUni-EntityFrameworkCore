namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Data.Models;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> x)
        {
            x.HasMany(x => x.Pets).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            x.HasMany(x => x.Toys).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            x.HasMany(x => x.Foods).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
