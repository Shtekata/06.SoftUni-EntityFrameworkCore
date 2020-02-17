namespace PetStore.Services
{
    using System;
    using PetStore.Services.Models.Food;

    public interface IFoodService
    {
        void BuyFromDistributo(string name, double weight, decimal price, double profit, DateTime expirationDate, int brandId, int categoryId);

        void BuyFromDistributor(AddingFoodServiceModel model);

        public void SellFoodToUser(int foodId, int userId);

        public bool Exists(int foodId);
    }
}
