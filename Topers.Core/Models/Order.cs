namespace Topers.Core.Models;

/// <summary>
/// Represents an order.
/// </summary>
public class Order
{
    public Order(Guid id, DateTime date, Customer customer, decimal totalPrice)
    {
        Id = id;
        Date = date;
        Customer = customer;
        TotalPrice = totalPrice;
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
    /// Gets or sets an order customer.
    /// </summary>
    public Customer Customer { get; } = null!;

    /// <summary>
    /// Gets or sets an order total price.
    /// </summary>
    public decimal TotalPrice { get; } = 0;
}