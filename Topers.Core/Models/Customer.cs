namespace Topers.Core.Models;

/// <summary>
/// Represents a customer.
/// </summary>
public class Customer
{
    public Customer(Guid id, Address? address, string name, string email, string phone)
    {
        Id = id;
        Address = address;
        Name = name;
        Email = email;
        Phone = phone;
    }

    /// <summary>
    /// Gets or sets a customer identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets a customer address.
    /// </summary>
    public Address? Address { get; }

    /// <summary>
    /// Gets or sets a customer name.
    /// </summary>
    public string Name { get; } = string.Empty;

    /// <summary>
    /// Gets or sets a customer identifier.
    /// </summary>
    public string Email { get; } = string.Empty;

    /// <summary>
    /// Gets or sets a customer identifier.
    /// </summary>
    public string Phone { get; } = string.Empty;
}