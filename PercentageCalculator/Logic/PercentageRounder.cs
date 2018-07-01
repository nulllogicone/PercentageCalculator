using System;
using System.Collections.Generic;
using System.Linq;
using PercentageCalculator.Models;

namespace PercentageCalculator.Logic
{
    public class PercentageRounder
    {
        public List<int> Execute(ICollection<decimal> rawPercentages)
        {
            var percentageInfos = rawPercentages
                                 .Select((percentage, index) => new PercentageInfo(index, percentage))
                                 .OrderByDescending(percentageInfo => percentageInfo.Remainder)
                                 .ToList();

            var total = (int) Math.Round(rawPercentages.Sum());
            AdjustPercentageInfos(total, percentageInfos);

            return percentageInfos.OrderBy(percentageInfo => percentageInfo.Index)
                                  .Select(percentageInfo => percentageInfo.Value)
                                  .ToList();
        }

        private static void AdjustPercentageInfos(int total, List<PercentageInfo> percentageInfos)
        {
            var remainder = total - percentageInfos.Sum(p => p.Value);
            foreach (var percentageInfo in percentageInfos)
            {
                if (remainder == 0)
                {
                    break;
                }

                percentageInfo.Value++;
                remainder--;
            }
        }
    }
}