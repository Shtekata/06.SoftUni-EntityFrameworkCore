namespace EFCodeFirstTest.Data
{
    using EFCodeFirstTest.Data.Models;
    using Microsoft.EntityFrameworkCore;
    class StudentsDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<StudentInCourse> StudentsInCourses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasOne(st => st.Town).WithMany(t => t.Students).HasForeignKey(st => st.TownId);

            modelBuilder.Entity<Student>().HasMany(x => x.Homeworks).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Course>().HasMany(x => x.Homeworks).WithOne(x => x.Course).HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<Town>().HasData(new Town { Name = "Sofia" });

            modelBuilder.Entity<StudentInCourse>().HasKey(x => new { x.CourseId, x.StudentId });

            modelBuilder.Entity<StudentInCourse>().HasOne(x => x.Student).WithMany(x => x.Courses).HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<StudentInCourse>().HasOne(x => x.Course).WithMany(x => x.Students).HasForeignKey(x => x.CourseId);
        }
    }
}
