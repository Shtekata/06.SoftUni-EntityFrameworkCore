namespace PrototypePattern
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var menu = new SandwichMenu();

            menu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");

            menu["LoadedBLT"] = new Sandwich("", "", "", "");

            var bltSandwich = menu["BLT"].Clone() as Sandwich;
        }
    }
}
