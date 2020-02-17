namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> x)
        {
            x.HasKey(y => y.TownId);
            x.Property(y => y.Name).HasMaxLength(50).IsRequired().IsUnicode();
            x.HasOne(y => y.Country).WithMany(y => y.Towns).HasForeignKey(y => y.CountryId);
        }
    }
}
