namespace TemplatePattern
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var tg = new TwelveGrain();
            var sd = new Sourdough();
            var ww = new WholeWheat();

            tg.Make();
            sd.Make();
            ww.Make();
        }
    }
}
