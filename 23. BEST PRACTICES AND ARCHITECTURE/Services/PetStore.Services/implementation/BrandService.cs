namespace PetStore.Services.implementation
{
    using System.Collections.Generic;
    using Models.Brand;
    using Data;
    using PetStore.Data.Models;
    using System;
    using System.Linq;
    using Models.Toy;

    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;

        public BrandService(PetStoreDbContext data) => this.data = data;

        public int Create(string name)
        {
            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Brand name cannot be more than {DataValidation.NameMaxLength} characters.");
            }

            if (data.Brands.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Brand name {name} already exists.");
            }

            var brand = new Brand
            {
                Name = name
            };

            data.Brands.Add(brand);
            data.SaveChanges();

            return brand.Id;
        }

        public BrandWithToysServiceModel FindByIdWithToys(int id) => data.Brands
            .Where(x => x.Id == id)
            .Select(x => new BrandWithToysServiceModel
            {
                Name = x.Name,
                Toys = x.Toys.Select(x => new ToyListingServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    TotalOrders = x.Orders.Count
                })
            })
            .FirstOrDefault();
        

        public IEnumerable<BrandListingServiceModel> SearchByName(string name) => data.Brands
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .Select(x => new BrandListingServiceModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();
    }
}
