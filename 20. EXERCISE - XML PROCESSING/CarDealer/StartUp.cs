using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using AutoMapper.QueryableExtensions;
using CarDealer.Dtos.Export;
using System.Text;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<CarDealerProfile>());

            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputXml1 = File.ReadAllText("./../../../Datasets/suppliers.xml");
                //var result1 = ImportSuppliers(db, inputXml1);
                //Console.WriteLine(result1);

                //var inputXml2 = File.ReadAllText("./../../../Datasets/parts.xml");
                //var result2 = ImportParts(db, inputXml2);
                //Console.WriteLine(result2);

                //var inputXml3 = File.ReadAllText("./../../../Datasets/cars.xml");
                //var result3 = ImportCars(db, inputXml3);
                //Console.WriteLine(result3);

                //var imputXml4 = File.ReadAllText("./../../../Datasets/customers.xml");
                //var result4 = ImportCustomers(db, imputXml4);
                //Console.WriteLine(result4);

                //var inputXml5 = File.ReadAllText("./../../../Datasets/sales.xml");
                //var result5 = ImportSales(db, inputXml5);
                //Console.WriteLine(result5);

                //var result6 = GetCarsWithDistance(db);
                //Console.WriteLine(result6);

                var result7 = GetCarsFromMakeBmw(db);
                Console.WriteLine(result7);

                //var result4 = GetLocalSuppliers(db);
                //Console.WriteLine(result4);

                //var result5 = GetCarsWithTheirListOfParts(db);
                //Console.WriteLine(result5);
            }
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] supplierDtos;

            using (var reader = new StringReader(inputXml))
            {
                supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            }

            var suppliers = Mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerialiser = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            ImportPartDto[] importPartDtos;

            using (var reader = new StringReader(inputXml))
            {
                importPartDtos = ((ImportPartDto[])xmlSerialiser.Deserialize(reader))
                    .Where(x => context.Suppliers.Any(y => y.Id == x.SupplierId))
                    .ToArray();
            }

            var parts = Mapper.Map<Part[]>(importPartDtos);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xlmSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            ImportCarDto[] carDtos;

            using (var reader = new StringReader(inputXml))
            {
                carDtos = (ImportCarDto[])xlmSerializer.Deserialize(reader);
            }

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var item in carDtos)
            {
                var car = new Car()
                {
                    Make = item.Make,
                    Model = item.Model,
                    TravelledDistance = item.TravelledDistance,
                };

                var parts = item.Parts
                    .Where(x => context.Parts.Any(y => y.Id == x.Id))
                    .Select(x => x.Id)
                    .Distinct();

                foreach (var item2 in parts)
                {
                    var partCar = new PartCar()
                    {
                        Car = car,
                        PartId = item2
                    };

                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            ImportCustomerDto[] importCustomerDto;

            using (var reader = new StringReader(inputXml))
            {
                importCustomerDto = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);
            }

            var customers = new List<Customer>();

            foreach (var x in importCustomerDto)
            {
                var customer = new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";

        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            ImportSaleDto[] importSaleDtos;

            using (var reader = new StringReader(inputXml))
            {
                importSaleDtos = ((ImportSaleDto[])xmlSerializer.Deserialize(reader))
                    .Where(x => context.Cars.Any(y => y.Id == x.CarId))
                    .ToArray();
            }

            var sales = new List<Sale>();

            foreach (var x in importSaleDtos)
            {
                var sale = new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10);

            var carsDtos = new List<ExportCarDistanceDto>();

            foreach (var x in cars)
            {
                var carsDto = new ExportCarDistanceDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                };

                carsDtos.Add(carsDto);
            }

            var xmlSerializer = new XmlSerializer(typeof(List<ExportCarDistanceDto>), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using(var writer=new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, carsDtos, namespaces);
            }

            return sb.ToString().Trim();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance);

            var carsDtos = new List<ExpotrBMW>();

            foreach (var x in cars)
            {
                var carDto = new ExpotrBMW
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                };

                carsDtos.Add(carDto);
            }

            var xmlSerializer = new XmlSerializer(typeof(List<ExpotrBMW>), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using(var writer=new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, carsDtos, namespaces);
            }

            return sb.ToString().Trim();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .ProjectTo<ExportLocalSuppliersDto>()
                .ToArray();

            var xmlSerialiser = new XmlSerializer(typeof(ExportLocalSuppliersDto[]), new XmlRootAttribute("suppliers"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerialiser.Serialize(writer, suppliers, namespaces);
            }

            return sb.ToString().Trim();
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var cars = context.Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ProjectTo<ExportCarDto>()
                .ToArray();

            //foreach (var item in cars)
            //{
            //    item.Parts = item.Parts
            //        .OrderByDescending(x => x.Price)
            //        .ToArray();
            //}

            var xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().Trim();
        }
    }
}