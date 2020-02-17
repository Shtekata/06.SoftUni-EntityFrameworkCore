namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> x)
        {
            x.HasKey(y => y.BetId);
            x.Property(y => y.Amount).IsRequired();
            x.Property(y => y.Prediction).IsRequired();
            x.Property(y => y.DateTime).IsRequired();
            x.HasOne(y => y.User).WithMany(y => y.Bets).HasForeignKey(y => y.UserId);
            x.HasOne(y => y.Game).WithMany(y => y.Bets).HasForeignKey(y => y.GameId);
        }
    }
}
