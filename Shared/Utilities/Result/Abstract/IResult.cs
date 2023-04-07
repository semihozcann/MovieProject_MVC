namespace Shared.Utilities.Result.Abstract
{
    public interface IResult
    {

        bool Success { get; }
        string? Message { get; }

    }
}
