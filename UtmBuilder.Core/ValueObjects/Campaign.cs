using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

public class Campaign : ValueObject
{
    /// <summary>
    /// Represents a campaign associated with a UTM (Urchin Tracking Module).
    /// </summary>
    /// <remarks>
    /// This class is immutable and encapsulates the standard UTM parameters used to track 
    /// the effectiveness of marketing campaigns across various channels.
    /// </remarks>
    /// <param name="source">The referrer (e.g. google, newsletter).</param>
    /// <param name="medium">The marketing medium (e.g., cpc, banner, email).</param>
    /// <param name="name">The specific product or promotion name (e.g., black_friday).</param>
    /// <param name="id">The ads campaign id (optional).</param>
    /// <param name="term">The paid keywords used for the campaign (optional).</param>
    /// <param name="content">Used to differentiate similar content or links within the same ad (optional).</param>
    public Campaign(string source,
        string medium,
        string name,
        string? id = null,
        string? term = null,
        string? content = null)
    {
        Source = source;
        Medium = medium;
        Name = name;
        Id = id;
        Term = term;
        Content = content;

        InvalidCampaignException.ThrowIfNull(source, "Invalid source.");
        InvalidCampaignException.ThrowIfNull(medium, "Invalid medium.");
        InvalidCampaignException.ThrowIfNull(name, "Invalid name.");
    }

    /// <summary>
    /// Gets the traffic source (utm_source), identifying the origin of the traffic.
    /// </summary>
    public string Source { get; }

    /// <summary>
    /// Gets the marketing medium (utm_medium), such as 'email' or 'social'.
    /// </summary>
    public string Medium { get; }

    /// <summary>
    /// Gets the campaign name (utm_campaign) used to identify a specific product promotion.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the campaign identifier (utm_id) used to track specific ads integrations.
    /// </summary>
    public string? Id { get; }

    /// <summary>
    /// Gets the campaign term (utm_term), typically used for paid search keywords.
    /// </summary>
    public string? Term { get; }

    /// <summary>
    /// Gets the campaign content (utm_content), used to distinguish between different links in the same ad.
    /// </summary>
    public string? Content { get; }
}