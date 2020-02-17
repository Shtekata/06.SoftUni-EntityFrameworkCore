namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> x)
        {
            x.HasKey(y => y.CountryId);
            x.Property(y => y.Name).HasMaxLength(50).IsRequired().IsUnicode();
        }
    }
}
