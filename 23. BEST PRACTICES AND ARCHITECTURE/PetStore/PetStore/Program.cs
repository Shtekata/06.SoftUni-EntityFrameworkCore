namespace PetStore
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Services.implementation;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            using var data = new PetStoreDbContext();

            for (int i = 0; i < 10; i++)
            {
                var breed = new Breed
                {
                    Name = "Breed " + i,
                };

                data.Breeds.Add(breed);
            }

            data.SaveChanges();

            for (int i = 0; i < 30; i++)
            {
                var category = new Category
                {
                    Name = "Category " + i,
                    Description = "Category Description " + i,
                };

                data.Categories.Add(category);
                data.SaveChanges();
            }

            for (int i = 0; i < 100; i++)
            {
                var breedId = data.Breeds
                    .OrderBy(x => Guid.NewGuid())
                    .Select(x => x.Id)
                    .FirstOrDefault();

                var categoryId = data.Categories
                    .OrderBy(x => Guid.NewGuid())
                    .Select(x => x.Id)
                    .FirstOrDefault();

                var pet = new Pet
                {
                    DateOfBirth = DateTime.UtcNow.AddDays(-60 + i),
                    Price = 50 + i,
                    Gender = (Gender)(i % 2),
                    Description = "Some random description" + i,
                    CategoryId = categoryId,
                    BreedId = breedId
                };

                data.Pets.Add(pet);
            }

            data.SaveChanges();

            ////var brandService = new BrandService(data);
            ////brandService.Create("Purrina");
            ////var brandWithToys = brandService.FindByIdWithToys(1);

            ////var foodService = new FoodService(data);
            ////foodService.BuyFromDistributo("Cat food", 0.350, 1.1m, 0.3, DateTime.Now, 1, 1);

            ////var toyService = new ToyService(data);
            ////toyService.BuyFromDistributor("Ball", null, 3.50m, 0.3, 1, 1);

            //var userService = new UserService(data);
            ////userService.Register("Pesho", "pesho123@mail.com");
            //var foodService = new FoodService(data, userService);
            ////foodService.SellFoodToUser(1, 1);
            //var toyService = new ToyService(data, userService);
            ////toyService.SellToyToUser(1, 1);
            //var breedService = new BreedService(data);
            ////breedService.Add("Persian");
            //var categoryService = new CategoryService(data);
            //var petService = new PetService(data, breedService, categoryService, userService);
            //petService.BuyPet(Gender.Male, DateTime.Now, 0m, null, 1, 1);
            //petService.SellPet(1, 1);

        }
    }
}
