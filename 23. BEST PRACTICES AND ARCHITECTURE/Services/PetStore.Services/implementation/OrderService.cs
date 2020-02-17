namespace PetStore.Services.implementation
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly PetStoreDbContext data;

        public OrderService(PetStoreDbContext data)
        {
            this.data = data;
        }
        public void CompleteOrder(int orderId)
        {
            var order = data.Orders
                .Find(orderId);
            order.Status = OrderStatus.Done;

            data.SaveChanges();
        }
    }
}
