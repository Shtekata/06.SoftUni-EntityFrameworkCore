using System;

namespace TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void MixIngridients()
        {
            Console.WriteLine("Gatering Ingridients for Sourdough bread!");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough bread! (20 minutes)");
        }

    }
}
