namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> x)
        {
            x.HasKey(y => new { y.PlayerId, y.GameId });
            x.Property(y => y.ScoredGoals).IsRequired();
            x.Property(y => y.Assists).IsRequired();
            x.Property(y => y.MinutesPlayed).IsRequired();
            x.HasOne(y => y.Game).WithMany(y => y.PlayerStatistics).HasForeignKey(y => y.GameId);
            x.HasOne(y => y.Player).WithMany(y => y.PlayerStatistics).HasForeignKey(y => y.PlayerId);
        }
    }
}
