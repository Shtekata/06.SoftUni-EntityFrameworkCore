namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
    {
        public void Configure(EntityTypeBuilder<FoodOrder> x)
        {
            x.HasKey(x => new {x.FoodId, x.OrderId});
            x.HasOne(x => x.Food).WithMany(x => x.Orders).HasForeignKey(x => x.FoodId).OnDelete(DeleteBehavior.Restrict);
            x.HasOne(x => x.Order).WithMany(x => x.Foods).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
