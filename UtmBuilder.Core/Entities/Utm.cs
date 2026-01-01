using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Entities;

public class Utm
{
    public Url Url { get; private set; }
    public Campain Campain { get; private set; }
}