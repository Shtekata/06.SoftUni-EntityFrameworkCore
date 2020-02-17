using System;

namespace TemplatePattern
{

    public class TwelveGrain : Bread
    {
        public override void MixIngridients()
        {
            Console.WriteLine("Gathering Ingridients for 12-Grain bread!");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread! (25 minutes)");
        }

        
    }
}
