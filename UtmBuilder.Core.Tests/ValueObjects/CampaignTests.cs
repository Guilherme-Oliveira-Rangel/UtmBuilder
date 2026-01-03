using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

public class CampaignTests
{
    private const string ValidSource = "source";
    private const string InvalidSource = "";
    private const string ValidMedium = "medium";
    private const string InvalidMedium = "";
    private const string ValidName = "name";
    private const string InvalidName = "";

    [Theory]
    [InlineData(InvalidSource, InvalidMedium, InvalidName, true)]
    [InlineData(InvalidSource, ValidMedium, ValidName, true)]
    [InlineData(ValidSource, InvalidMedium, ValidName, true)]
    [InlineData(ValidSource, ValidMedium, InvalidName, true)]
    [InlineData(ValidSource, ValidMedium, ValidName, false)]
    public void ShouldThrowInvalidCampaignExceptionForInvalidSource(string source, string medium, string name,
        bool expectException)
    {
        if (expectException)
        {
            try
            {
                _ = new Campaign(source, medium, name);
                Assert.Fail();
            }
            catch (InvalidCampaignException)
            {
                Assert.True(true);
            }
        }
        else
        {
            _ = new Campaign(source, medium, name);
            Assert.True(true);
        }
    }
}