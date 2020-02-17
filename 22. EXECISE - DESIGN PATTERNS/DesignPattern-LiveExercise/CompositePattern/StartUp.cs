namespace CompositePattern
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine("-----------------------");

            var rootBox = new CompositGift("RootBox", 0);
            var truckToy = new SingleGift("TruckToy", 289);
            var plainToy = new SingleGift("PlainToy", 587);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            var childBox = new CompositGift("ChildBox", 0);
            var soldierToy = new SingleGift("SoldierToy", 200);
            childBox.Add(soldierToy);

            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");

        }
    }
}
