namespace P03_SalesDatabase.Data
{
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(x =>
            {
                x.HasKey(y => y.ProductId);
                x.Property(y => y.Name).HasMaxLength(50).IsRequired().IsUnicode();
                x.Property(y => y.Description).HasMaxLength(250).IsRequired(false).IsUnicode().HasDefaultValue("No description");
                x.Property(y => y.Quantity).IsRequired();
                x.Property(y => y.Price).IsRequired();
            });

            modelBuilder.Entity<Customer>(x =>
            {
                x.HasKey(y => y.CustomerId);
                x.Property(y => y.Name).HasMaxLength(100).IsRequired().IsUnicode();
                x.Property(y => y.Email).HasMaxLength(80).IsRequired().IsUnicode(false);
                x.Property(y => y.CreditCardNumber).IsRequired().IsUnicode(false);
            });

            modelBuilder.Entity<Store>(x =>
            {
                x.HasKey(y => y.StoreId);
                x.Property(y => y.Name).HasMaxLength(80).IsRequired().IsUnicode();
            });

            modelBuilder.Entity<Sale>(x =>
            {
                x.HasKey(y => y.SaleId);
                x.Property(y => y.Date).IsRequired().HasColumnType("DATETIME2").HasDefaultValueSql("GETDATE()");

                x.HasOne(y => y.Product).WithMany(y => y.Sales).HasForeignKey(y => y.ProductId);
                x.HasOne(y => y.Customer).WithMany(y => y.Sales).HasForeignKey(y => y.CustomerId);
                x.HasOne(y => y.Store).WithMany(y => y.Sales).HasForeignKey(y => y.StoreId);
            });
        }
    }
}
