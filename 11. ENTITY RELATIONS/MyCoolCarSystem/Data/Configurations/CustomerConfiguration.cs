namespace MyCoolCarSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCoolCarSystem.Data.Models;

    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> x)
        {
            x.HasOne(x => x.Address).WithOne(x => x.Customer).HasForeignKey<Address>(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
