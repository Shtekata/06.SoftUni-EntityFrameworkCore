using System;

namespace TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void MixIngridients()
        {
            Console.WriteLine("Gathering Ingridients for WholeWheat bread!");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the WholeWheat bread! (15 minutes)");
        }
    }
}
