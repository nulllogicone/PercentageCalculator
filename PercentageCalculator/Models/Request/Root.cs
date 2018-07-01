using System.Collections.Generic;

namespace PercentageCalculator.Models.Request
{
    public class Root
    {
        public Root()
        {
            Data = new List<Data>();
        }

        public List<Data> Data { get; set; }

        public int Decimals { get; set; }
    }
}