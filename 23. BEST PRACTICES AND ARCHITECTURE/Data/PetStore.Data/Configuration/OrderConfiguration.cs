namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> x)
        {
            x.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            x.HasMany(x => x.Pets).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
