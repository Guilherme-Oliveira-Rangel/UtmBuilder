using UtmBuilder.Core.Entities;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests.Entities;

public class UtmTests
{
    private const string ValidUrl = "https://example.com/";
    private const string ValidSource = "source";
    private const string ValidMedium = "medium";
    private const string ValidName = "name";
    private const string ValidId = "id";
    private const string ValidTerm = "term";
    private const string ValidContent = "content";

    private const string ValidUtmString =
        "https://example.com/?utm_source=source&utm_medium=medium&utm_campaign=name&utm_id=id&utm_term=term&utm_content=content";

    [Fact]
    public void ShouldReturnUrlFromUtm()
    {
        var url = new Url(ValidUrl);
        var campaign = new Campaign(
            ValidSource,
            ValidMedium,
            ValidName,
            ValidId,
            ValidTerm,
            ValidContent
        );

        var utm = new Utm(url, campaign);
        
        Assert.Equal(ValidUtmString, utm.ToString());
        Assert.Equal(ValidUtmString, (string)utm);
    }

    [Fact]
    public void ShouldReturnUtmFromString()
    {
        Utm utm = ValidUtmString;

        Assert.Multiple(() =>
        {
            Assert.Equal(ValidSource, utm.Campaign.Source);
            Assert.Equal(ValidMedium, utm.Campaign.Medium);
            Assert.Equal(ValidName, utm.Campaign.Name);
            Assert.Equal(ValidId, utm.Campaign.Id);
            Assert.Equal(ValidTerm, utm.Campaign.Term);
            Assert.Equal(ValidContent, utm.Campaign.Content);
        });
    }
}