using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

public class UrlTests
{
    private const string ValidUrl =
        "https://example.com/products/shoes?utm_source=google&utm_medium=cpc&utm_campaign=spring_sale&utm_id=12345&utm_term=running+shoes&utm_content=ad_variant_a";

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