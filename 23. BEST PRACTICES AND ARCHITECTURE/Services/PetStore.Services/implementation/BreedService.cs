namespace PetStore.Services.implementation
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using System;
    using System.Linq;

    public class BreedService : IBreedService
    {
        private readonly PetStoreDbContext data;
        public BreedService(PetStoreDbContext data)
        {
            this.data = data;
        }
        public void Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Breed name cannot be null or whitespace!");
            }

            var breed = new Breed()
            {
                Name = name
            };

            data.Breeds.Add(breed);
            data.SaveChanges();
        }

        public bool Exists(int breedId)
        {
            return data.Breeds.Any(x => x.Id == breedId);
        }
    }
}
