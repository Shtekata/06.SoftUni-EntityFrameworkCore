namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class ToyOrderConfiguration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> x)
        {
            x.HasKey(x => new { x.OrderId, x.ToyId });
            x.HasOne(x => x.Order).WithMany(x => x.Toys).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
            x.HasOne(x => x.Toy).WithMany(x => x.Orders).HasForeignKey(x => x.ToyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
