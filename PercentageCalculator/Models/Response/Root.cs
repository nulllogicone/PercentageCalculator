using System.Collections.Generic;

namespace PercentageCalculator.Models.Response
{
    public class Root
    {
        public Root()
        {
            Data = new List<Data>();
        }

        public List<Data> Data { get; set; }
    }
}