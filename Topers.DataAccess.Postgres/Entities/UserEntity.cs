namespace Topers.DataAccess.Postgres.Entities;

/// <summary>
/// Represents a user entity.
/// </summary>
public class UserEntity
{
    /// <summary>
    /// Gets or sets a user identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a user name.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a user hash password.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a user email.
    /// </summary>
    public string Email { get; set; } = string.Empty;
}