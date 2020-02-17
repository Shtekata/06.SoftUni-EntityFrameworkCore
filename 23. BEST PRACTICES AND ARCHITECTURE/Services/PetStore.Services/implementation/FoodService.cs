namespace PetStore.Services.implementation
{
    using System;
    using System.Linq;
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Services.Models.Food;

    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userServices;
        public FoodService(PetStoreDbContext data, IUserService userServices)
        {
            this.data = data;
            this.userServices = userServices;
        }
        public void BuyFromDistributo(string name, double weight, decimal price, double profit, DateTime expirationDate, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException("Profit must be higher than zero and lower than 500%");
            }

            var food = new Food()
            {
                Name = name,
                Weidht = weight,
                DistributorPrice = price,
                Price = price + (price * (decimal)profit),
                ExpirationDate = expirationDate,
                BrandId = brandId,
                CategoryId = categoryId
            };

            data.Foods.Add(food);
            data.SaveChanges();
        }

        public void BuyFromDistributor(AddingFoodServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException("Profit must be higher than zero and lower than 500%");
            }

            var food = new Food()
            {
                Name = model.Name,
                Weidht = model.Weight,
                DistributorPrice = model.Price,
                Price = model.Price + (model.Price * (decimal)model.Profit),
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            data.Foods.Add(food);
            data.SaveChanges();
        }

        public void SellFoodToUser(int foodId, int userId)
        {
            if (!Exists(foodId))
            {
                throw new ArgumentException("There is no such food with given id in the datebase!");
            }

            if (!userServices.Exists(userId))
            {
                throw new ArgumentException("There is no such user with given id in the datebase!");
            }

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId
            };

            var foodOrder = new FoodOrder()
            {
                FoodId = foodId,
                Order = order
            };

            data.Orders.Add(order);
            data.FoodOrders.Add(foodOrder);
            data.SaveChanges();
        }

        public bool Exists(int foodId)
        {
            return data.Foods.Any(x => x.Id == foodId);
        }
    }
}
