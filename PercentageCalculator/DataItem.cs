using System;
using System.Collections.Generic;
using System.Text;

namespace PercentageCalculator
{

    public class Input
    {
        public List<DataItem> Values { get; set; }
    }
    public class DataItem
    {
        public string Label { get; set; }

        public int Value { get; set; }
    }
}
