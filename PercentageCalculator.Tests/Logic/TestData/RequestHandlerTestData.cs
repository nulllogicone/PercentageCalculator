using System.Collections.Generic;
using PercentageCalculator.Models.Request;
using Xunit;
using RequestRoot = PercentageCalculator.Models.Request.Root;
using ResponseRoot = PercentageCalculator.Models.Response.Root;

namespace PercentageCalculator.Tests.Logic.TestData
{
    public class RequestHandlerTestData
    {
        public static TheoryData<RequestRoot, List<int>, ResponseRoot> RequestsRoundedToIntegers =
                new TheoryData<RequestRoot, List<int>, ResponseRoot>
                {
                        {
                                new RequestRoot
                                {
                                        Data = new List<Data>
                                               {
                                                       new Data
                                                       {
                                                               Text = "text1",
                                                               Value = 33
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text2",
                                                               Value = 33
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text3",
                                                               Value = 34
                                                       }
                                               },
                                        Decimals = 0
                                },
                                new List<int>
                                {
                                        33,
                                        33,
                                        34
                                },
                                new ResponseRoot
                                {
                                        Data = new List<PercentageCalculator.Models.Response.Data>
                                               {
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 33,
                                                               Text = "text1",
                                                               Value = 33
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 33,
                                                               Text = "text2",
                                                               Value = 33
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 34,
                                                               Text = "text3",
                                                               Value = 34
                                                       }
                                               }
                                }
                        },
                        {
                                new RequestRoot
                                {
                                        Data = new List<Data>
                                               {
                                                       new Data
                                                       {
                                                               Text = "text1",
                                                               Value = 15
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text2",
                                                               Value = 19
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text3",
                                                               Value = 18
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text4",
                                                               Value = 30
                                                       }
                                               },
                                        Decimals = 0
                                },
                                new List<int>
                                {
                                        18,
                                        23,
                                        22,
                                        37
                                },
                                new ResponseRoot
                                {
                                        Data = new List<PercentageCalculator.Models.Response.Data>
                                               {
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 18,
                                                               Text = "text1",
                                                               Value = 15
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 23,
                                                               Text = "text2",
                                                               Value = 19
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 22,
                                                               Text = "text3",
                                                               Value = 18
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 37,
                                                               Text = "text4",
                                                               Value = 30
                                                       }
                                               }
                                }
                        },
                        {
                                new RequestRoot
                                {
                                        Data = new List<Data>
                                               {
                                                       new Data
                                                       {
                                                               Text = "text1",
                                                               Value = 11
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text2",
                                                               Value = 13
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text3",
                                                               Value = 16
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text4",
                                                               Value = 13
                                                       }
                                               },
                                        Decimals = 0
                                },
                                new List<int>
                                {
                                        21,
                                        25,
                                        30,
                                        24
                                },
                                new ResponseRoot
                                {
                                        Data = new List<PercentageCalculator.Models.Response.Data>
                                               {
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 21,
                                                               Text = "text1",
                                                               Value = 11
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 25,
                                                               Text = "text2",
                                                               Value = 13
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 30,
                                                               Text = "text3",
                                                               Value = 16
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 24,
                                                               Text = "text4",
                                                               Value = 13
                                                       }
                                               }
                                }
                        },
                        {
                                new RequestRoot
                                {
                                        Data = new List<Data>
                                               {
                                                       new Data
                                                       {
                                                               Text = "text1",
                                                               Value = 15
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text2",
                                                               Value = 14
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text3",
                                                               Value = 17
                                                       },
                                                       new Data
                                                       {
                                                               Text = "text4",
                                                               Value = 30
                                                       }
                                               },
                                        Decimals = 0
                                },

                                new List<int>
                                {
                                        20,
                                        18,
                                        22,
                                        40
                                },
                                new ResponseRoot
                                {
                                        Data = new List<PercentageCalculator.Models.Response.Data>
                                               {
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 20,
                                                               Text = "text1",
                                                               Value = 15
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 18,
                                                               Text = "text2",
                                                               Value = 14
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 22,
                                                               Text = "text3",
                                                               Value = 17
                                                       },
                                                       new PercentageCalculator.Models.Response.Data
                                                       {
                                                               Percentage = 40,
                                                               Text = "text4",
                                                               Value = 30
                                                       }
                                               }
                                }
                        }
                };
    }
}