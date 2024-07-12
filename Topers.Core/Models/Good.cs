namespace Topers.Core.Models;

using Microsoft.AspNetCore.Http;

/// <summary>
/// Represents a good.
/// </summary>
public class Good
{
    public Good(Guid id, Guid categoryId, string name, string description)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Gets or sets a good identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets a good category identifier.
    /// </summary>
    public Guid CategoryId { get; }

    /// <summary>
    /// Gets or sets a good name.
    /// </summary>
    public string Name { get; } = string.Empty;

    /// <summary>
    /// Gets or sets a good description.
    /// </summary>
    public string? Description { get; } = string.Empty;
}