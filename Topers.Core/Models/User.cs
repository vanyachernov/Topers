namespace Topers.Core.Models;

/// <summary>
/// Represents a user.
/// </summary>
public class User
{
    public User() { }

    /// <summary>
    /// Gets a username.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets a hash password.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;
}