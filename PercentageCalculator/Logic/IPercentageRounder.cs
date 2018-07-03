using System.Collections.Generic;

namespace PercentageCalculator.Logic
{
    public interface IPercentageRounder
    {
        List<int> Execute(ICollection<decimal> rawPercentages);
    }
}