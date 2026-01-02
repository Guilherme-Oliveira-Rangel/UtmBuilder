namespace UtmBuilder.Core.ValueObjects.Exceptions;

public class InvalidCampaignException : Exception
{
    private const string DefaultErrorMessage = "Invalid Campaign";

    public InvalidCampaignException(string message = DefaultErrorMessage) : base(message)
    {
    }

    public static void ThrowIfInvalidCampaign(string? item, string message = DefaultErrorMessage)
    {
        if (string.IsNullOrWhiteSpace(item)) throw new InvalidUrlException(message);
    }
}