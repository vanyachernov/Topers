namespace Topers.Core.Models;

/// <summary>
/// Represents a customer address.
/// </summary>
public class Address
{
    public Address(Guid id, Guid customerId, string street, string city, string state, string postalCode, string country)
    {
        Id = id;
        CustomerId = customerId;
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    /// <summary>
    /// Gets or sets an address identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets a customer identifier.
    /// </summary>
    public Guid CustomerId { get; }

    /// <summary>
    /// Gets or sets a customer street.
    /// </summary>
    public string Street { get; } = String.Empty;

    /// <summary>
    /// Gets or sets a customer city.
    /// </summary>
    public string City { get; } = String.Empty;

    /// <summary>
    /// Gets or sets a customer state.
    /// </summary>
    public string State { get; } = String.Empty;

    /// <summary>
    /// Gets or sets a customer postal code.
    /// </summary>
    public string PostalCode { get; } = String.Empty;

    /// <summary>
    /// Gets or sets a customer coutry.
    /// </summary>
    public string Country { get; } = String.Empty;
}