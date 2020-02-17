namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> x)
        {
            x.HasKey(y => y.PlayerId);
            x.Property(y => y.Name).HasMaxLength(100).IsRequired().IsUnicode();
            x.Property(y => y.SquadNumber).IsRequired();
            x.Property(y => y.IsInjured).IsRequired();
            x.HasOne(y => y.Team).WithMany(y => y.Players).HasForeignKey(y => y.TeamId);
            x.HasOne(y => y.Position).WithMany(y => y.Players).HasForeignKey(y => y.PositionId);
        }
    }
}
