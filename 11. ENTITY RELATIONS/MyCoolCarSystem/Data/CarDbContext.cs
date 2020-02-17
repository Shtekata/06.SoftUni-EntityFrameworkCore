namespace MyCoolCarSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Data.Configurations;
    using System.Reflection;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarPurchase> Purchases { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public override int SaveChanges()
        {
            //var entries = ChangeTracker
            //    .Entries()
            //    .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            //foreach (var item in entries)
            //{
            //    var entity = item.Entity;

            //    var validationContext = new ValidationContext(entity);

            //    Validator.ValidateObject(entity, validationContext, true);
            //}

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(DataSettings.DefaultConnection);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        
           => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
    }
}
