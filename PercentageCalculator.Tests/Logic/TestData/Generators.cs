using System.Collections.Generic;
using FsCheck;
using PercentageCalculator.Models.Request;

namespace PercentageCalculator.Tests.Logic.TestData
{
    public static class Generators
    {
        private const int ListCountLowerBound = 1;
        private const int ListCountUpperBound = 10;

        private const int ValueLowerBound = 1;
        private const int ValueUpperBound = 1000;

        public static Arbitrary<List<Data>> DataList
        {
            get => Arb.From(DataListGen);
        }

        private static readonly Gen<List<Data>> DataListGen = Gen.Choose(ListCountLowerBound, ListCountUpperBound)
                                                                 .Select(CreateList);

        private static List<Data> CreateList(int maxI)
        {
            var random = new System.Random();
            var result = new List<Data>();
            for (var i = 0; i < maxI; i++)
            {
                var data = new Data
                           {
                                   Value = random.Next(ValueLowerBound, ValueUpperBound)
                           };
                result.Add(data);
            }

            return result;
        }
    }
}