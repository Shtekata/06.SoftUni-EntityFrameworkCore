namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Data.Models;

    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> x)
        {
            x.HasMany(x => x.Pets).WithOne(x => x.Breed).HasForeignKey(x => x.BreedId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
