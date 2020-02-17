using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public class CompositGift : GiftBase, IGiftOperation
    {
        private List<GiftBase> _gifts;

        public CompositGift(string name, int price)
            :base(name, price)
        {
            _gifts = new List<GiftBase>();
        }
        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            var total = 0;

            Console.WriteLine($"{name} contains the following produts with prices:");

            foreach (var item in _gifts)
            {
                total += item.CalculateTotalPrice();
            }

            return total;
        }

    }
}
