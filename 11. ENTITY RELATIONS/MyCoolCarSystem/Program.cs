namespace MyCoolCarSystem
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using MyCoolCarSystem.Results;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Diagnostics;
    using MyCoolCarSystem.Data.Queries;
    using Z.EntityFramework.Plus;

    public class Program
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            db.Database.Migrate();

            using var data = new CarDbContext();

            var car = data.Cars
                .FirstOrDefault(x => x.Id == 1);

            data.Entry(car)
                .Collection(x => x.Owners)
                .Load();

            Console.WriteLine(car.Owners.FirstOrDefault().PurchaseDate);

            ;

            //var cars = data.Cars
            //    .Where(x => x.Price < 20000)
            //    .Update(x => new Car { Price = x.Price * 1.2m });

            //data.Cars
            //    .Where(x => x.Price < 200000)
            //    .ToList()
            //    .ForEach(x => x.Price *= 1.2m);

            //data.SaveChanges();



            //var price = 5000;
            //
            //var stopwatch = Stopwatch.StartNew();
            //
            //db.Cars
            //    .Where(x => x.Price > price)
            //    .Where(x => x.Owners.Any(x => x.Customer.LastName == null))
            //    .Select(x => new ResultModel
            //    {
            //        Count = x.Owners.Count(x => x.Customer.Purchases.Count > 1)
            //    })
            //    .ToList();
            //
            //Console.WriteLine(stopwatch.Elapsed + " Cold");
            //
            //stopwatch = Stopwatch.StartNew();
            //
            //db.Cars
            //    .Where(x => x.Price > price)
            //    .Where(x => x.Owners.Any(x => x.Customer.LastName == null))
            //    .Select(x => new ResultModel
            //    {
            //        Count = x.Owners.Count(x => x.Customer.Purchases.Count > 1)
            //    })
            //    .ToList();
            //
            //Console.WriteLine(stopwatch.Elapsed + " Warm");
            //
            //stopwatch = Stopwatch.StartNew();
            //
            //CarQueries.ToResult(db, price);
            //
            //Console.WriteLine(stopwatch.Elapsed + " Compiled Query With Compilation");
            //
            //stopwatch = Stopwatch.StartNew();
            //
            //CarQueries.ToResult(db, price);
            //
            //Console.WriteLine(stopwatch.Elapsed + " Compiled Query");

            //var result = db.Purchases.Select(x => new PuchaseResultModel
            //{
            //    Price = x.Price,
            //    PurchaseDate = x.PurchaseDate,
            //    Customer = new CustomerResultModel
            //    {
            //        Name = x.Customer.FirstName + " " + x.Customer.LastName,
            //        Town = x.Customer.Address.Town
            //    },
            //    Car = new CarResultModel
            //    {
            //        Vin = x.Car.Vin,
            //        Make = x.Car.Model.Make.Name,
            //        Model = x.Car.Model.Name
            //    }
            //}).ToList();

            //var make = db.Makes.FirstOrDefault(x => x.Name == "Mercedes");
            //
            //var model = new Model
            //{
            //    Modification = "500",
            //    Name = "CL",
            //    Year = 3000
            //};
            //
            //make.Models.Add(model);
        }
    }
}
