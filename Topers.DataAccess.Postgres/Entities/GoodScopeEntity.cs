using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

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

    /// <summary>
    /// Gets or sets a good image.
    /// </summary>
    public string? Image { get; set; } = string.Empty;

    [NotMapped]
    /// <summary>
    /// Gets or sets a good image file.
    /// </summary>
    public IFormFile? ImageFile { get; set; }

    /// <summary>
    /// Gets or sets an order details about good.
    /// </summary>
    public ICollection<OrderDetailsEntity>? OrderDetails { get; set; } = [];
    public ICollection<CartItemEntity>? CartDetails { get; set; } = [];
}
