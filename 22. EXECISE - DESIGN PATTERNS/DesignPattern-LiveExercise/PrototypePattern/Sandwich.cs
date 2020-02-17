using System;

namespace PrototypePattern
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string vegies;

        public Sandwich(string bread, string meat, string cheese, string vegies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.vegies = vegies;
        }
        public override SandwichPrototype Clone()
        {
            var ingridiens = GetIngridientsList();
            Console.WriteLine($"Cloning sandwich with ingridients: {ingridiens}");

            return this.MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngridientsList()
        {
            return $"{bread}, {meat}, {cheese}, {vegies}";
        }
    }
}
