namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> x)
        {
            x.HasKey(y => y.GameId);
            x.Property(y => y.HomeTeamGoals).IsRequired();
            x.Property(y => y.AwayTeamGoals).IsRequired();
            x.Property(y => y.DateTime).IsRequired();
            x.Property(y => y.HomeTeamBetRate).IsRequired();
            x.Property(y => y.AwayTeamBetRate).IsRequired();
            x.Property(y => y.DrawBetRate).IsRequired();
            x.Property(y => y.Result).HasMaxLength(7).IsRequired().IsUnicode(false);
            x.HasOne(y => y.HomeTeam).WithMany(y => y.HomeGames).HasForeignKey(y => y.HomeTeamId).OnDelete(DeleteBehavior.Restrict);
            x.HasOne(y => y.AwayTeam).WithMany(y => y.AwayGames).HasForeignKey(y => y.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
