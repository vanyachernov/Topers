using Topers.Core.Models;

namespace Topers.DataAccess.Postgres.Entities;

/// <summary>
/// Represents an order details.
/// </summary>
public class OrderDetailsEntity
{
    /// <summary>
    /// Gets or sets an order details identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets an order identifier.
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Gets or sets an order.
    /// </summary>
    public OrderEntity Order { get; set; } = null!;

    /// <summary>
    /// Gets or sets a good identifier.
    /// </summary>
    public Guid GoodId { get; set; }

    /// <summary>
    /// Gets or sets a good.
    /// </summary>
    public GoodScopeEntity Good { get; set; } = null!;

    /// <summary>
    /// Gets or sets a good quantity.
    /// </summary>
    public int Quantity { get; set; } = 0;

    /// <summary>
    /// Gets or sets a good price.
    /// </summary>
    public decimal Price { get; set; } = 0;
}