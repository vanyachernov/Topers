namespace Topers.Core.Models;

/// <summary>
/// Represents a good scope entity.
/// </summary>
public class GoodScope
{
    public GoodScope(Guid id, Guid goodId, int litre, decimal price, string? image)
    {
        Id = id;
        GoodId = goodId;
        Litre = litre;
        Price = price;
        ImageName = image;
    }

    /// <summary>
    /// Gets or sets a good scope identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets a good identifier.
    /// </summary>
    public Guid GoodId { get; }

    /// <summary>
    /// Gets or sets the volume in liters.
    /// </summary>
    public int Litre { get; }
    
    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    public string? ImageName { get; }
}