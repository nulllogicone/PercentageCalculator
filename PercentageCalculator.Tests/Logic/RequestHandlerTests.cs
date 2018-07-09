using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using FsCheck.Xunit;
using NSubstitute;
using PercentageCalculator.Logic;
using PercentageCalculator.Tests.Logic.TestData;
using Xunit;
using RequestData = PercentageCalculator.Models.Request.Data;
using RequestRoot = PercentageCalculator.Models.Request.Root;
using ResponseRoot = PercentageCalculator.Models.Response.Root;

namespace PercentageCalculator.Tests.Logic
{
    [Properties(Arbitrary = new[] {typeof(Generators)})]
    public class RequestHandlerTests
    {
        [Theory]
        [MemberData(nameof(RequestHandlerTestData.RequestsRoundedToIntegers), MemberType = typeof(RequestHandlerTestData))]
        public void Execute_RequestsRoundedToIntegers_ResponseIsCorrect(RequestRoot request, List<int> roundedPercentages, ResponseRoot expectedResult)
        {
            var percentageCalculator = Substitute.For<IPercentageRounder>();
            percentageCalculator.Execute(Arg.Any<ICollection<decimal>>()).Returns(roundedPercentages);
            var requestHandler = new RequestHandler(percentageCalculator);

            var result = requestHandler.Execute(request);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Property]
        public void Execute_Response_Percentages_Add_Up_To_100(List<RequestData> dataList)
        {
            var percentageRounder = new PercentageRounder();
            var requestHandler = new RequestHandler(percentageRounder);

            var request = new RequestRoot
                          {
                                  Decimals = 0,
                                  Data = dataList
                          };

            var result = requestHandler.Execute(request);

            result.Data.Sum(x => x.Percentage).Should().Be(100);
        }

        [Property]
        public void Execute_Largest_Value_Has_The_Largest_Percentage(List<RequestData> dataList)
        {
            var percentageRounder = new PercentageRounder();
            var requestHandler = new RequestHandler(percentageRounder);

            var request = new RequestRoot
                          {
                                  Decimals = 0,
                                  Data = dataList
                          };

            var result = requestHandler.Execute(request);

            var dataWithLargestValue = result.Data.OrderByDescending(x => x.Value).First();
            var dataWithLargestPercentage = result.Data.OrderByDescending(x => x.Percentage).First();

            dataWithLargestValue.Should().Be(dataWithLargestPercentage);
        }

        [Property]
        public void Execute_All_Percentage_Values_Are_Positive(List<RequestData> dataList)
        {
            var percentageRounder = new PercentageRounder();
            var requestHandler = new RequestHandler(percentageRounder);

            var request = new RequestRoot
                          {
                                  Decimals = 0,
                                  Data = dataList
                          };

            var result = requestHandler.Execute(request);
            var allPercentagesArePositive = result.Data.All(x => x.Percentage > 0);

            allPercentagesArePositive.Should().BeTrue();
        }

        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void Constructor_NullAsPercentageRounder_ThrowsArgumentNullException()
        {
            Action action = () =>
                            {
                                var requestHandler = new RequestHandler(null);
                            };

            action.Should().Throw<ArgumentException>().Where(x => x.ParamName == "percentageRounder");
        }

        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void Execute_NullAsRequest_ThrowsArgumentNullException()
        {
            var percentageCalculator = Substitute.For<IPercentageRounder>();
            var requestHandler = new RequestHandler(percentageCalculator);

            Action action = () =>
                            {
                                var result = requestHandler.Execute(null);
                            };

            action.Should().Throw<ArgumentException>().Where(x => x.ParamName == "request");
        }

        [Fact]
        public void Execute_RequestHasZeroDataItems_ReturnsEmptyResponse()
        {
            var percentageCalculator = Substitute.For<IPercentageRounder>();
            var requestHandler = new RequestHandler(percentageCalculator);

            var request = new RequestRoot();
            var expectedResult = new ResponseRoot();

            var response = requestHandler.Execute(request);

            response.Should().BeEquivalentTo(expectedResult);
        }
    }
}