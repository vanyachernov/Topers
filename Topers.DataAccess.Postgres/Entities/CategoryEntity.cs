namespace Topers.DataAccess.Postgres.Entities;

/// <summary>
/// Represents a category entity.
/// </summary>
public class CategoryEntity
{
    /// <summary>
    /// Gets or sets a category identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a category name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a category description.
    /// </summary>
    public string? Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a category goods.
    /// </summary>
    public ICollection<GoodEntity> Goods { get; set; } = [];
}