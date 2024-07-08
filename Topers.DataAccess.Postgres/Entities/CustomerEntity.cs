namespace Topers.DataAccess.Postgres.Entities;

/// <summary>
/// Represents a customer entity.
/// </summary>
public class CustomerEntity
{
    /// <summary>
    /// Gets or sets a customer identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a customer name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a customer email.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a customer phone.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a customer address identifier.
    /// </summary>
    public Guid AddressId { get; set; }

    /// <summary>
    /// Gets or sets a customer address.
    /// </summary>
    public AddressEntity? Address { get; set; }

    /// <summary>
    /// Gets or sets a customer orders.
    /// </summary>
    public ICollection<OrderEntity> Orders { get; set; } = [];
}