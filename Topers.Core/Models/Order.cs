namespace Topers.Core.Models;

/// <summary>
/// Represents an order.
/// </summary>
public class Order
{
    public Order(Guid id, DateTime date, Guid customerId, decimal totalPrice)
    {
        Id = id;
        Date = date;
        CustomerId = customerId;
        TotalPrice = totalPrice;
        OrderDetails = [];
    }

    /// <summary>
    /// Gets or sets an order identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets an order date.
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Gets or sets an order customer identifier.
    /// </summary>
    public Guid CustomerId { get; }

    /// <summary>
    /// Gets or sets an order total price.
    /// </summary>
    public decimal TotalPrice { get; } = 0;

    /// <summary>
    ///  Gets or sets a good scopes.
    /// </summary>
    public ICollection<OrderDetails> OrderDetails { get; set; }
}