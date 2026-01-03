using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

public class UrlTests
{
    private const string ValidUrl = "https://example.com";
    private const string InvalidUrl = "";

    [Fact]
    public void ShouldNotThrowInvalidUrlExceptionWhenUrlIsValid()
    {
        _ = new Url(ValidUrl);

        Assert.True(true);
    }

    [Fact]
    public void ShouldThrowInvalidUrlExceptionWhenUrlIsInvalid()
    {
        Assert.Throws<InvalidUrlException>(() =>
        {
            var url = new Url(InvalidUrl);
        });
    }
}