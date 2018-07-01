namespace PercentageCalculator.Logic
{
    public interface IRequestHandler
    {
        Models.Response.Root Execute(Models.Request.Root input);
    }
}