namespace Topers.DataAccess.Postgres.Entities;

/// <summary>
/// Represents an item in the shopping cart.
/// </summary>
public class CartItemEntity
{
    /// <summary>
    /// Gets or sets the cart item identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the cart identifier.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// Gets or sets the cart.
    /// </summary>
    public CartEntity Cart { get; set; } = null!;

    /// <summary>
    /// Gets or sets the good identifier.
    /// </summary>
    public Guid GoodId { get; set; }

    /// <summary>
    /// Gets or sets the good.
    /// </summary>
    public GoodScopeEntity Good { get; set; } = null!;

    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }
}
