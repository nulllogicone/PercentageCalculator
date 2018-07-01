using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PercentageCalculator.Tests.Models
{
    //public PercentageInfo(int index, decimal number)
    //{
    //  Index = index;
    //  Value = (int)Math.Floor(number);
    //  Remainder = (int)(number % 1 * 100);
    //}

    public class PercentageInfoTests
    {
        [Fact]
        public void Constructor_NegativeIndex_ThrowsArgumentException()
        {

        }

        [Fact]
        public void Constructor_NegativeNumber_ThrowsArgumentException()
        {

        }

        [Fact]
        public void Constructor_PositiveNumber_SetsValueToItsFloor()
        {

        }

        [Fact]
        public void Constructor_PositiveNumber_SetsRamineder()
        {

        }
    }
}
