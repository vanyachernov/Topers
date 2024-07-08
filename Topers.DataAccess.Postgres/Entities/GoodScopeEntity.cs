namespace Topers.DataAccess.Postgres.Entities;

/// <summary>
/// Represents a good scope entity.
/// </summary>
public class GoodScopeEntity
{
    /// <summary>
    /// Gets or sets a good scope identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a good identifier.
    /// </summary>
    public Guid GoodId { get; set; }

    /// <summary>
    /// Gets or sets a good.
    /// </summary>
    public GoodEntity Good { get; set; } = null!;

    /// <summary>
    /// Gets or sets the volume in liters.
    /// </summary>
    public int Litre { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    public decimal Price { get; set; }
}