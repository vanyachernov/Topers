namespace Topers.Core.Models;

/// <summary>
/// Represents a customer cart.
/// </summary>
public class Cart
{
    public Cart(Guid id, Guid customerId, DateTime createdDate, DateTime updatedDate)
    {
        Id = id;
        CustomerId = customerId;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    /// <summary>
    /// Gets a cart identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets a customer identifier.
    /// </summary>
    public Guid CustomerId { get; }

    /// <summary>
    /// Gets a cart created date.
    /// </summary>
    public DateTime CreatedDate { get; }

    /// <summary>
    /// Gets a cart updated date.
    /// </summary>
    public DateTime UpdatedDate { get; }
}
