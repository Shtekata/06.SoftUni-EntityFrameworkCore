namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> x)
        {
            x.HasKey(y => y.PositionId);
            x.Property(y => y.Name).HasMaxLength(20).IsRequired().IsUnicode();
        }
    }
}
