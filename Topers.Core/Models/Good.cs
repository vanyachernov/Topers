namespace Topers.Core.Models;

using Microsoft.AspNetCore.Http;

/// <summary>
/// Represents a good.
/// </summary>
public class Good
{
    public Good(Guid id, Guid categoryId, string name, string description, string imageName, IFormFile image)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        ImageName = imageName;
        Image = image;
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

    /// <summary>
    /// Gets or sets a good image name file.
    /// </summary>
    public string? ImageName { get; } = string.Empty;

    /// <summary>
    /// Gets or sets a good image.
    /// </summary>
    public IFormFile? Image { get; }
}