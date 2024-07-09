namespace Topers.Core.Models;

/// <summary>
/// Represents a category.
/// </summary>
public class Category
{
    public Category(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Gets or sets a category identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets a category name.
    /// </summary>
    public string Name { get; } = string.Empty;

    /// <summary>
    /// Gets or sets a category description.
    /// </summary>
    public string? Description { get; } = string.Empty;
}