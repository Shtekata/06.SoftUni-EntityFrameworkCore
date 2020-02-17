namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> x)
        {
            x.HasKey(y => y.UserId);
            x.Property(y => y.Username).HasMaxLength(50).IsRequired().IsUnicode(false);
            x.Property(y => y.Password).HasMaxLength(30).IsRequired().IsUnicode(false);
            x.Property(y => y.Email).HasMaxLength(50).IsRequired().IsUnicode(false);
            x.Property(y => y.Name).HasMaxLength(100).IsRequired(false).IsUnicode();
            x.Property(y => y.Balance).IsRequired();
        }
    }
}
