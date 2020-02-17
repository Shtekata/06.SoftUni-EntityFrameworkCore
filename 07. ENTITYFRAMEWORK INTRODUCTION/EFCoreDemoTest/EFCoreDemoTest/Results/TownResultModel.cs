using System.Collections.Generic;

namespace EFCoreDemoTest.Results
{
    public class TownResultModel
    {
        public string Name { get; set; }
        public IEnumerable<string> Adresses { get; set; }
    }
}
