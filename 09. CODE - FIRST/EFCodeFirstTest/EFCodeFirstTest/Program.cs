namespace EFCodeFirstTest
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Diagnostics;

    public class Program
    {
        public static void Main()
        {
            using (var db = new StudentsDbContext())
            {
                db.Database.Migrate();
            }

            var stopwatch = Stopwatch.StartNew();

            using (var db = new StudentsDbContext())
            {
                SameQuery(db);
            }

            Console.WriteLine(stopwatch.Elapsed);

            stopwatch = Stopwatch.StartNew();

            using (var db = new StudentsDbContext())
            {
                SameQuery(db);
            }

            Console.WriteLine(stopwatch.Elapsed);

        }

        private static void SameQuery(StudentsDbContext db)
        {
            var student = db.Students.FirstOrDefault().FullName;
            var courses = db.Courses
                .Select(x => new
                {
                    x.Name,
                    TotalStudents = x.Students.Where(y => y.Course.Homeworks.Average(z => z.Score) > 2).Count(),
                    Students = x.Students.Select(y => new { FullName = y.Student.FirstName + " " + y.Student.LastName, Score = y.Student.Homeworks.Average(z => z.Score) })
                }).ToList();

            Console.WriteLine(courses.Count);
        }
    }
}
