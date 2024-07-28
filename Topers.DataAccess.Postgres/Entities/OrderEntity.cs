namespace Topers.DataAccess.Postgres.Entities;

/// <summary>
/// Represents an order.
/// </summary>
public class OrderEntity
{
    /// <summary>
    /// Gets or sets an order identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets an order date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets an order customer identifier.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets an order customer.
    /// </summary>
    public CustomerEntity Customer { get; set; } = null!;

    /// <summary>
    /// Gets or sets an order total price.
    /// </summary>
    public decimal TotalPrice { get; set; } = 0;

    /// <summary>
    /// Gets or sets an order details.
    /// </summary>
    public ICollection<OrderDetailsEntity> OrderDetails { get; set; } = [];
}