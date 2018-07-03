using Xunit;

namespace PercentageCalculator.Tests.Logic.TestData
{
    public class PercentageRounderTestData
    {
        public static TheoryData<decimal[], int[]> RoundedPercentagesAddUpTo100 =
                new TheoryData<decimal[], int[]>
                {
                        {
                                new[]
                                {
                                        33m,
                                        33m,
                                        34m
                                },
                                new[]
                                {
                                        33,
                                        33,
                                        34
                                }
                        },
                        {
                                // input values: 15, 19, 18, 30
                                new[]
                                {
                                        18.2926m,
                                        23.1707m,
                                        21.9512m,
                                        36.5853m
                                },
                                new[]
                                {
                                        18,
                                        23,
                                        22,
                                        37
                                }
                        }
                };

        public static TheoryData<decimal[], int[]> RoundedPercentagesAddUpTo101 =
                new TheoryData<decimal[], int[]>
                {
                        {
                                new[]
                                {
                                        34.7m,
                                        44.7m,
                                        20.6m
                                },
                                new[]
                                {
                                        35,
                                        45,
                                        20
                                }
                        },
                        {
                                // input values: 11, 13, 16, 13
                                new[]
                                {
                                        20.7547m,
                                        24.5283m,
                                        30.1886m,
                                        24.5283m
                                },
                                new[]
                                {
                                        21,
                                        25,
                                        30,
                                        24
                                }
                        }
                };

        public static TheoryData<decimal[], int[]> RoundedPercentagesAddUpTo99 =
                new TheoryData<decimal[], int[]>
                {
                        {
                                new[]
                                {
                                        33.334m,
                                        33.333m,
                                        33.333m
                                },
                                new[]
                                {
                                        34,
                                        33,
                                        33
                                }
                        },
                        {
                                // input values: 15, 14, 17, 30
                                new[]
                                {
                                        19.7368m,
                                        18.421m,
                                        22.3684m,
                                        39.4736m
                                },
                                new[]
                                {
                                        20,
                                        18,
                                        22,
                                        40
                                }
                        }
                };
    }
}