using EFCoreDemoTest.Data;
using EFCoreDemoTest.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDemoTest
{
    class Program
    {
        static void Main()
        {
            //var result = GetTownData();
            //
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //using var db = new SoftUniContext();
            //
            //var result = db.Employees
            //    //.Select(e => new { Name = e.FirstName + " " + e.LastName, Department = e.Department.Name })
            //    .Select(e => new EmployeeResultModel { Name = e.FirstName + " " + e.LastName, Department = e.Department.Name })
            //    .Skip(5)
            //    .Take(10)
            //    .ToList();
            //
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Name} {item.Department}");
            //}

            using var db = new SoftUniContext();

            //var town = new Town { Name = "New Town" };

            //town.Addresses.Add(new Addresses { AddressText = "Rio" });

            //db.Add(town);

            //var town = new Town { TownId = 33, Name = "Even Newer Town" };
            //
            //db.Update(town);

            //var town = db.Towns.Find(33);
            //
            //town.Name = "Old Town";

            //db.Towns.Remove(new Town { TownId = 33 });

            //var town = db.Towns.Find(33);

            var town = db.Towns
                .Select(t => new { t.TownId, Addresses = t.Addresses.Select(a => a.AddressId) })
                .FirstOrDefault(t => t.TownId == 33);

            foreach (var item in town.Addresses)
            {
                db.Addresses.Remove(new Addresses { AddressId = item });
            }

            db.Remove(new Town { TownId = town.TownId });

            db.SaveChanges();
        }
        private static IEnumerable<TownResultModel> GetTownData()
        {
            using (var db = new SoftUniContext())
            {
                var result = db.Towns
                    .Where(t => t.Name.StartsWith("S"))
                    .Select(t => new TownResultModel { Name = t.Name, Adresses = t.Addresses.Select(t => t.AddressText) })
                    .ToList();

                return result;
            }
        }
    }
}
