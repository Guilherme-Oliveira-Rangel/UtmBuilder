using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Entities;

public class Utm
{
    public const string UtmSource = "utm_source";
    public const string UtmMedium = "utm_medium";
    public const string UtmCampaign = "utm_campaign";
    public const string UtmId = "utm_id";
    public const string UtmTerm = "utm_term";
    public const string UtmContent = "utm_content";

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

    public static implicit operator string(Utm utm)
    {
        return utm.ToString();
    }

    public static implicit operator Utm(string address)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidUrlException();

        var url = new Url(address);

        var segments = url.Address.Split("?");
        if (segments.Length == 1)
            throw new InvalidUrlException("No segments exist in the given url");

        var parameters = segments[1].Split("&");

        var source = parameters.Where(x => x.StartsWith(UtmSource)).FirstOrDefault().Split("=")[1];
        var medium = parameters.Where(x => x.StartsWith(UtmMedium)).FirstOrDefault().Split("=")[1];
        var name = parameters.Where(x => x.StartsWith(UtmCampaign)).FirstOrDefault().Split("=")[1];
        var id = parameters.Where(x => x.StartsWith(UtmId)).FirstOrDefault().Split("=")[1];
        var term = parameters.Where(x => x.StartsWith(UtmTerm)).FirstOrDefault().Split("=")[1];
        var content = parameters.Where(x => x.StartsWith(UtmContent)).FirstOrDefault().Split("=")[1];

        Utm utm = new(new Url(segments[0]), new Campaign(source, medium, name, id, term, content));

        return utm;
    }

    public override string ToString()
    {
        var parameters = new List<string>();

        parameters.AddIfNotNull(UtmSource, Campaign.Source);
        parameters.AddIfNotNull(UtmMedium, Campaign.Medium);
        parameters.AddIfNotNull(UtmCampaign, Campaign.Name);
        parameters.AddIfNotNull(UtmId, Campaign.Id);
        parameters.AddIfNotNull(UtmTerm, Campaign.Term);
        parameters.AddIfNotNull(UtmContent, Campaign.Content);

        return $"{Url.Address}?{string.Join("&", parameters)}";
    }
}