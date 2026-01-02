using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

/// <summary>
/// Represents a URL value object for defining a web address within the UTM builder context.
/// </summary>
/// <remarks>
/// The <see cref="Url"/> class encapsulates a single string property, <see cref="Address"/>,
/// which holds the actual web address. This class is immutable, ensuring that once created,
/// the URL value cannot be altered.
/// </remarks>
public class Url : ValueObject
{
    /// <summary>
    /// Represents a URL value object.
    /// </summary>
    /// <remarks>
    /// The <see cref="Url"/> is part of the value objects in the domain-driven design
    /// and ensures encapsulation of the URL content within the domain.
    /// </remarks>
    public Url(string address)
    {
        Address = address;
        InvalidUrlException.ThrowIfInvalidUrl(address);
    }

    /// <summary>
    /// Gets the address of the URL.
    /// </summary>
    /// <remarks>
    /// The <c>Address</c> property holds the URL as a string.
    /// It is initialized during the creation of the <see cref="Url"/> instance
    /// and cannot be modified thereafter.
    /// </remarks>
    public string Address { get; }
}