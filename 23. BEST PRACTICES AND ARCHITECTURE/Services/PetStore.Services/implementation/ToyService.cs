namespace PetStore.Services.implementation
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Services.Models.Toy;
    using System;
    using System.Linq;

    public class ToyService : IToyService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userServices;

        public ToyService(PetStoreDbContext data, IUserService userServices)
        {
            this.data = data;
            this.userServices = userServices;
        }
        public void BuyFromDistributor(string name, string description, decimal distributorPrice, double profit, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException("Profit must be higher than zero and lower than 500%");
            }

            var toy = new Toy()
            {
                Name = name,
                Description = description,
                DistributorPrice = distributorPrice,
                Price = distributorPrice + (distributorPrice * (decimal)profit),
                BrandId = brandId,
                CategoryId = categoryId
            };

            data.Toys.Add(toy);
            data.SaveChanges();
        }

        public void BuyFromDistributor(AddingToyServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException("Profit must be higher than zero and lower than 500%");
            }

            var toy = new Toy()
            {
                Name = model.Name,
                Description = model.Description,
                DistributorPrice = model.Price,
                Price = model.Price + (model.Price * (decimal)model.Price),
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            data.Toys.Add(toy);
            data.SaveChanges();
        }

        public void SellToyToUser(int toyId, int userId)
        {
            if (!Exists(toyId))
            {
                throw new ArgumentException("There is no such toy with given id in the database!"); 
            }

            if (!userServices.Exists(userId))
            {
                throw new ArgumentException("There is no such user with given id in the database!");
            }

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId
            };

            var toyOrder = new ToyOrder()
            {
                ToyId = toyId,
                Order = order
            };

            data.Orders.Add(order);
            data.ToyOrders.Add(toyOrder);
            data.SaveChanges();
        }

        public bool Exists(int toyId)
        {
            return data.Toys.Any(x => x.Id == toyId);
        }
    }
}
