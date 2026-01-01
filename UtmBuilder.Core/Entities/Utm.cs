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
}