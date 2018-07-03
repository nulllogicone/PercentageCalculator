using System;
using FluentAssertions;
using PercentageCalculator.Models;
using Xunit;

namespace PercentageCalculator.Tests.Models
{
    public class PercentageInfoTests
    {
        [Theory]
        [InlineData(12, 12)]
        [InlineData(12.1, 12)]
        [InlineData(12.5, 12)]
        [InlineData(11.9, 11)]
        public void Constructor_PositiveNumber_SetsValueToItsFloor(decimal number, int expectedResult)
        {
            var percentageInfo = new PercentageInfo(0, number);

            var result = percentageInfo.Value;

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(12, 0)]
        [InlineData(12.001, 0)]
        [InlineData(12.01, 1)]
        [InlineData(12.1, 10)]
        [InlineData(12.5, 50)]
        [InlineData(11.9, 90)]
        public void Constructor_PositiveNumber_SetsRemainder(decimal number, decimal expectedResult)
        {
            var percentageInfo = new PercentageInfo(0, number);

            var result = percentageInfo.Remainder;

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Constructor_NegativeIndex_ThrowsArgumentException()
        {
            Action action = () =>
                            {
                                var percentageInfo = new PercentageInfo(-1, 0);
                            };

            action.Should().Throw<ArgumentException>().Where(x => x.ParamName == "index");
        }

        [Fact]
        public void Constructor_NegativeNumber_ThrowsArgumentException()
        {
            Action action = () =>
                            {
                                var percentageInfo = new PercentageInfo(0, -1);
                            };

            action.Should().Throw<ArgumentException>().Where(x => x.ParamName == "number");
            ;
        }
    }
}