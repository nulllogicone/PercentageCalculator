using System;
using System.Linq;
using PercentageCalculator.Models.Response;

namespace PercentageCalculator.Logic
{
    public class RequestHandler : IRequestHandler
    {
        private readonly IPercentageRounder _percentageRounder;

        public RequestHandler(IPercentageRounder percentageRounder)
        {
            _percentageRounder = percentageRounder ?? throw new ArgumentNullException(nameof(percentageRounder));
        }

        public Root Execute(Models.Request.Root request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            // TODO: add validation to Request.Root class
            if (request.Data.Count == 0)
            {
                return new Root();
            }

            var valueSum = request.Data.Sum(x => x.Value);

            var rawPercentages = request.Data.Select(x => (decimal) x.Value / valueSum * 100).ToList();

            var roundedPercentages = _percentageRounder.Execute(rawPercentages);
            var response = new Root();
            for (var i = 0; i < roundedPercentages.Count; i++)
            {
                var responseData = new Data
                                   {
                                           Percentage = roundedPercentages[i],
                                           Text = request.Data[i].Text,
                                           Value = request.Data[i].Value
                                   };
                response.Data.Add(responseData);
            }

            return response;
        }
    }
}