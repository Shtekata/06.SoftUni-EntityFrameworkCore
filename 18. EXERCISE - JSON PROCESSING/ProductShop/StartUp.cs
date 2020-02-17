using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dto;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Mapper.Initialize(x => x.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputJson1 = File.ReadAllText("./../../../Datasets/users.json");
                //var result1 = ImportUsers(db, inputJson1);
                //Console.WriteLine(result1);

                //var inputJson2 = File.ReadAllText("./../../../Datasets/products.json");
                //var result2 = ImportProducts(db, inputJson2);
                //Console.WriteLine(result2);

                //var inputJson3 = File.ReadAllText("./../../../Datasets/categories.json");
                //var result3 = ImportCategories(db, inputJson3);
                //Console.WriteLine(result3);

                //var inputJson4 = File.ReadAllText("./../../../Datasets/categories-products.json");
                //var result4 = ImportCategoryProducts(db, inputJson4);
                //Console.WriteLine(result4);

                //Console.WriteLine(GetUsersWithProducts(db));
                //Console.WriteLine(GetSoldProducts(db));
                Console.WriteLine(GetCategoriesByProductsCount(db));


            }
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);
            var categoriesNew = new List<Category>();

            foreach (var item in categories)
            {
                if (item.Name != null) { categoriesNew.Add(item); }
            }

            context.Categories.AddRange(categoriesNew);
            context.SaveChanges();

            return $"Successfully imported {categoriesNew.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(y => y.Buyer != null)
                    .Select(y => new
                    {
                        name = y.Name,
                        price = y.Price,
                        buyerFirstName = y.Buyer.FirstName,
                        buyerLastName = y.Buyer.LastName
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName);

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Where(z=>z.Product.Buyer!=null).Average(y=>y.Product.Price).ToString("f2"),
                    totalRevenue = x.CategoryProducts.Sum(y => y.Product.Price)
                });

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //var users = context
            //          .Users
            //          .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
            //          .Select(x => new
            //          {
            //              firstName = x.FirstName,
            //              lastName = x.LastName,
            //              age = x.Age,
            //              soldProducts = new
            //              {
            //                  count = x.ProductsSold.Where(y => y.Buyer != null).Count(),
            //                  products = x.ProductsSold.Where(y => y.Buyer != null)
            //                  .Select(y => new
            //                  {
            //                      name = y.Name,
            //                      price = y.Price
            //                  })
            //              }
            //          })
            //          .OrderByDescending(x => x.soldProducts.count)
            //          .ToArray();

            var users = context
                .Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .ProjectTo<UserDetailsDto>()
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToArray();


            //var output = new UserInfoDto
            //{
            //    UsersCount=users.Length,
            //    Users=users
            //};

            var output = Mapper.Map<UserInfoDto>(users);

            var defaultResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(output, new JsonSerializerSettings
            {
                ContractResolver=defaultResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            }
            );

            return json;
        }
    }
}