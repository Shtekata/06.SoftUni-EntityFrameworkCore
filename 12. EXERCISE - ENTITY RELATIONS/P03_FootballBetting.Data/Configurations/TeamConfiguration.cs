namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> x)
        {
            x.HasKey(y => y.TeamId);
            x.Property(y => y.Name).HasMaxLength(50).IsRequired().IsUnicode();
            x.Property(y => y.LogoUrl).HasMaxLength(250).IsRequired(false).IsUnicode(false);
            x.Property(y => y.Initials).HasMaxLength(3).IsRequired().IsUnicode();
            x.Property(y => y.Budget).IsRequired();
            x.HasOne(y => y.PrimaryKitColor).WithMany(y => y.PrimaryKitTeams).HasForeignKey(y => y.PrimaryKitColorId).OnDelete(DeleteBehavior.Restrict);
            x.HasOne(y => y.SecondaryKitColor).WithMany(y => y.SecondaryKitTeams).HasForeignKey(y => y.SecondaryKitColorId).OnDelete(DeleteBehavior.Restrict);
            x.HasOne(y => y.Town).WithMany(y => y.Teams).HasForeignKey(y => y.TownId);
        }
    }
}
