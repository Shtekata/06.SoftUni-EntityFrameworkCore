using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db=new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                var inputJson = File.ReadAllText("./../../../Datasets/cars.json");

                Console.WriteLine(ImportCars(db,inputJson));
            }
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(x => context.Suppliers.Any(y => y.Id == x.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var item in carsDto)
            {
                var car = new Car
                {
                    Make = item.Make,
                    Model = item.Model,
                    TravelledDistance = item.TravelledDistance
                };

                foreach (var part in item.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        Car = car,
                        PartId = part
                    };

                    carParts.Add(carPart);
                }

                cars.Add(car);
            }

            context.AddRange(cars);
            context.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";

        }
    }
}