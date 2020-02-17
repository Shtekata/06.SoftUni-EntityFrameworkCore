using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCoolCarSystem.Data.Models;

namespace MyCoolCarSystem.Data.Configurations
{
    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> x)
        {
            x.HasIndex(x => x.Name).IsUnique();
            x.HasMany(x => x.Models).WithOne(x => x.Make).HasForeignKey(x => x.MakeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
