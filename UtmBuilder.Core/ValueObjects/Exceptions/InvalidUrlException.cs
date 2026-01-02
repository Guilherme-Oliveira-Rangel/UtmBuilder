using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValueObjects.Exceptions;

public partial class InvalidUrlException : Exception
{
    private const string DefaultErrorMessage = "Invalid URL";

    private const string UrlRegexPattern =
        @"^(http|https):(\/\/www\.|\/\/www\.|\/\/|\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$|(http|https):(\/\/localhost:\d*|\/\/127\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\/.*)?$";


    public InvalidUrlException(string message = DefaultErrorMessage) : base(message)
    {
    }

    public static void ThrowIfInvalidUrl(string url, string message = DefaultErrorMessage)
    {
        if (string.IsNullOrWhiteSpace(url) || !UrlRegex().IsMatch(url)) throw new InvalidUrlException(message);
    }

    [GeneratedRegex(UrlRegexPattern)]
    private static partial Regex UrlRegex();
}