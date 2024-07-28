namespace Topers.Core.Models;

/// <summary>
/// Represents an order details.
/// </summary>
public class OrderDetails
{
    public OrderDetails(Guid id, Guid orderId, Guid goodId, int quantity, decimal price)
    {
        Id = id;
        OrderId = orderId;
        GoodId = goodId;
        Quantity = quantity;
        Price = price;
    }

    /// <summary>
    /// Gets or sets an order details identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets an order identifier.
    /// </summary>
    public Guid OrderId { get; }

    /// <summary>
    /// Gets or sets a good identifier.
    /// </summary>
    public Guid GoodId { get; }

    /// <summary>
    /// Gets or sets a good quantity.
    /// </summary>
    public int Quantity { get; } = 0;

    /// <summary>
    /// Gets or sets a good price.
    /// </summary>
    public decimal Price { get; } = 0;
}
