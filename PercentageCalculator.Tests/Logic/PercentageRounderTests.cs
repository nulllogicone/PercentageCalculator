using FluentAssertions;
using PercentageCalculator.Logic;
using PercentageCalculator.Tests.Logic.TestData;
using Xunit;

namespace PercentageCalculator.Tests.Logic
{
    public class PercentageRounderTests
    {
        [Theory]
        [MemberData(nameof(PercentageRounderTestData.RoundedPercentagesAddUpTo100), MemberType = typeof(PercentageRounderTestData))]
        public void Execute_RoundedNumbersAddUpTo100_ResultAddsUpTo100(decimal[] percentages, int[] expectedResult)
        {
            var percentageRounder = Create();

            var result = percentageRounder.Execute(percentages);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [MemberData(nameof(PercentageRounderTestData.RoundedPercentagesAddUpTo101), MemberType = typeof(PercentageRounderTestData))]
        public void Execute_RoundedNumbersAddUpTo101_ResultAddsUpTo100(decimal[] percentages, int[] expectedResult)
        {
            var percentageRounder = Create();

            var result = percentageRounder.Execute(percentages);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [MemberData(nameof(PercentageRounderTestData.RoundedPercentagesAddUpTo99), MemberType = typeof(PercentageRounderTestData))]
        public void Execute_RoundedNumbersAddUpTo99_ResultAddsUpTo100(decimal[] percentages, int[] expectedResult)
        {
            var percentageRounder = Create();

            var result = percentageRounder.Execute(percentages);

            result.Should().BeEquivalentTo(expectedResult);
        }

        private static PercentageRounder Create() => new PercentageRounder();
    }
}