using Microsoft.AspNetCore.Http;

namespace Topers.Core.Models;

/// <summary>
/// Represents a user.
/// </summary>
public class User
{
    private User(Guid id, string username, string passwordHash, string email) 
    {
        Id = id;
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
    }

    /// <summary>
    /// Gets or sets a user identifier.
    /// </summary>
    public Guid Id { get; set;}

    /// <summary>
    /// Gets a user name.
    /// </summary>
    public string Username { get; } = string.Empty;

    /// <summary>
    /// Gets a user hash password.
    /// </summary>
    public string PasswordHash { get; } = string.Empty;

    /// <summary>
    /// Gets a user email.
    /// </summary>
    public string Email { get; } = string.Empty;

    public static User Create(Guid id, string username, string passwordHash, string email)
    {
        return new User(id, username, passwordHash, email);
    }
}