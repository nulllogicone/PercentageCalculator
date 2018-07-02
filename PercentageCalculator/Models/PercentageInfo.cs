using System;

namespace PercentageCalculator.Models
{
    public class PercentageInfo
    {
        public PercentageInfo(int index, decimal number)
        {
            if (index < 0)
            {
                throw new ArgumentException(string.Empty, nameof(index));
            }

            if (number < 0)
            {
                throw new ArgumentException(string.Empty, nameof(number));
            }

            Index = index;
            Value = (int) Math.Floor(number);
            Remainder = (int) (number % 1 * 100);
        }

        public int Index { get; set; }

        public decimal Remainder { get; set; }

        public int Value { get; set; }
    }
}