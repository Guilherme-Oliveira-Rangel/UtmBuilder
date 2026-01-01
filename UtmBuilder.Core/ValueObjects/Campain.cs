namespace UtmBuilder.Core.ValueObjects;

public class Campain : ValueObject
{
    public string Id { get; private set; }
    public string Source { get; private set; }
    public string Medium { get; private set; }
    public string Name { get; private set; }
    public string Term { get; private set; }
    public string Content { get; private set; }
}