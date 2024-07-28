namespace Topers.Core.Models;

/// <summary>
/// Represents a customer cart.
/// </summary>
public class CartItems
{
    public CartItems(Guid id, Guid cartId, Guid goodId, int quantity, decimal price)
    {
        Id = id;
        CartId = cartId;
        GoodId = goodId;
        Quantity = quantity;
        Price = price;
    }

    /// <summary>
    /// Gets a cart item identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets a cart identifier.
    /// </summary>
    public Guid CartId { get; }

    /// <summary>
    /// Gets a cart good scope identifier.
    /// </summary>
    public Guid GoodId { get; }

    /// <summary>
    /// Gets a good quantity.
    /// </summary>
    public int Quantity { get; } = 0;

    /// <summary>
    /// Gets a good price.
    /// </summary>
    public decimal Price { get; } = 0;
}
