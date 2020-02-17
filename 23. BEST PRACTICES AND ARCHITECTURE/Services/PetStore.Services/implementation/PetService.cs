namespace PetStore.Services.implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Services.Models.Pet;

    public class PetService : IPetService
    {
        private const int PetsPageSize = 25;

        private readonly PetStoreDbContext data;
        private readonly IBreedService breedService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userServices;

        public PetService(PetStoreDbContext data, IBreedService breedService, ICategoryService categoryService, IUserService userServices)
        {
            this.data = data;
            this.breedService = breedService;
            this.categoryService = categoryService;
            this.userServices = userServices;
        }
        public void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price of the pet cannot be less than zero");
            }

            if (!breedService.Exists(breedId))
            {
                throw new ArgumentException("There is no such breed with given id in database!");
            }

            if (!categoryService.Exists(categoryId))
            {
                throw new ArgumentException("There is no such category with given id in database!");
            }

            var pet = new Pet()
            {
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Price = price,
                Description = description,
                BreedId = breedId,
                CategoryId = categoryId
            };

            data.Pets.Add(pet);
            data.SaveChanges();
        }

        public void SellPet(int petId, int userId)
        {
            if (!userServices.Exists(userId))
            {
                throw new ArgumentException("There is no such user with given id in database!");
            }

            if (!Exists(petId))
            {
                throw new ArgumentException("There is no such pet with given id in database");
            }

            var pet = data.Pets.First(x => x.Id == petId);

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId,
            };

            data.Orders.Add(order);
            pet.Order = order;

            data.SaveChanges();
        }

        public bool Exists(int petId)
        {
            return data.Pets.Any(x => x.Id == petId);
        }

        public IEnumerable<PetListingServiceModel> All(int page = 1) => data.Pets
            .Skip((page - 1) * PetsPageSize)
            .Take(PetsPageSize)
            .Select(x => new PetListingServiceModel
            {
                Id = x.Id,
                Price = x.Price,
                Category = x.Category.Name,
                Breed = x.Breed.Name,
            })
            .ToList();

        public int Total() => data.Pets.Count();

        public PetDetailsServiceModel Details(int id) => data.Pets
            .Where(x => x.Id == id)
            .Select(x => new PetDetailsServiceModel
            {
                Id = x.Id,
                Breed = x.Breed.Name,
                Category = x.Category.Name,
                DateOfBirth = x.DateOfBirth,
                Description = x.Description,
                Gender = x.Gender,
                Price = x.Price
            })
            .FirstOrDefault();

        public bool Delete(int id)
        {
            var pet = data.Pets.Find(id);

            if (pet == null)
            {
                return false;
            }

            data.Pets.Remove(pet);
            data.SaveChanges();

            return true;
        }
    }
}
