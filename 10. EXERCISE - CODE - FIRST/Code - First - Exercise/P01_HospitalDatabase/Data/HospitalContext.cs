using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options) 
            : base(options)
        {
        }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

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
            modelBuilder.Entity<Diagnose>(x =>
            {
                x.HasKey(y => y.DiagnoseId);
                x.Property(y => y.Name).HasMaxLength(50).IsRequired().IsUnicode();
                x.Property(y => y.Comments).HasMaxLength(250).IsRequired().IsUnicode();

                x.HasOne(y => y.Patient).WithMany(y => y.Diagnoses).HasForeignKey(y => y.PatientId);
            });
            modelBuilder.Entity<Medicament>(x =>
            {
                x.HasKey(y => y.MedicamentId);
                x.Property(y => y.Name).HasMaxLength(50).IsRequired().IsUnicode();
            });
            modelBuilder.Entity<Visitation>(x =>
            {
                x.HasKey(y => y.VisitationId);
                x.Property(y => y.Date).IsRequired().HasColumnType("DATETIME2");
                x.Property(y => y.Comments).HasMaxLength(250).IsRequired().IsUnicode();

                x.HasOne(y => y.Patient).WithMany(y => y.Visitations).HasForeignKey(y => y.PatientId);
                x.HasOne(y => y.Doctor).WithMany(y => y.Visitations).HasForeignKey(y => y.PatientId);
            });
            modelBuilder.Entity<Patient>(x =>
            {
                x.HasKey(y => y.PatientId);
                x.Property(y => y.FirstName).HasMaxLength(50).IsRequired().IsUnicode();
                x.Property(y => y.LastName).HasMaxLength(50).IsRequired().IsUnicode();
                x.Property(y => y.Address).HasMaxLength(250).IsRequired().IsUnicode();
                x.Property(y => y.Email).HasMaxLength(80).IsRequired().IsUnicode(false);
                x.Property(y => y.HasInsurance).IsRequired();
            });
            modelBuilder.Entity<PatientMedicament>(x =>
            {
                x.HasKey(y => new { y.PatientId, y.MedicamentId });
                x.HasOne(y => y.Patient).WithMany(y => y.Prescriptions).HasForeignKey(y => y.PatientId);
                x.HasOne(y => y.Medicament).WithMany(y => y.Prescriptions).HasForeignKey(y => y.MedicamentId);
            });
            modelBuilder.Entity<Doctor>(x =>
            {
                x.HasKey(y => y.DoctorId);
                x.Property(y => y.Name).HasMaxLength(100).IsRequired().IsUnicode();
                x.Property(y => y.Specialty).HasMaxLength(100).IsRequired().IsUnicode();
            });
        }
    }
}
