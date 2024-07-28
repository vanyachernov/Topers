namespace Topers.DataAccess.Postgres.Entities;

/// <summary>
/// Represents a shopping cart.
/// </summary>
public class CartEntity
{
    /// <summary>
    /// Gets or sets the cart identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// ets or sets the customer.
    /// </summary>
    public CustomerEntity Customer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date when the cart was created.
    /// </summary>
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date when the cart was last updated.
    /// </summary>
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the cart items.
    /// </summary>
    public ICollection<CartItemEntity> CartItems { get; set; } = [];
}
