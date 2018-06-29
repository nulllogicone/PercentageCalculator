using Microsoft.WindowsAzure.Storage.Table;

namespace PercentageCalculator
{
    internal class PercentageCalculatorEntity :TableEntity
    {
        public PercentageCalculatorEntity()
        {
        }

        public string Request { get; set; }
        public string Response { get; set; }
    }
}