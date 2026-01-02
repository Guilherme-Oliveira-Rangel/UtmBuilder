using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Entities;

public class Utm
{
    public Utm(Url url, Campaign campaign)
    {
        Url = url;
        Campaign = campaign;
    }

    /// <summary>
    /// Gets the URL associated with the current UTM instance.
    /// </summary>
    public Url Url { get; }

    /// <summary>
    /// Represents a campaign within a UTM (Urchin Tracking Module) context.
    /// </summary>
    public Campaign Campaign { get; }

    public override string ToString()
    {
        var parameters = new List<string>();

        parameters.AddIfNotNull("utm_source", Campaign.Source);
        parameters.AddIfNotNull("utm_medium", Campaign.Medium);
        parameters.AddIfNotNull("utm_campaign", Campaign.Name);
        parameters.AddIfNotNull("utm_id", Campaign.Id);
        parameters.AddIfNotNull("utm_term", Campaign.Term);
        parameters.AddIfNotNull("utm_content", Campaign.Content);

        return $"{Url.Address}?{string.Join("&", parameters)}";
    }
}