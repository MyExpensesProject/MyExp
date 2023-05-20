using Microsoft.AspNetCore.Identity;

namespace Users.Domain.Entities;

/// <summary>
/// Role entity
/// </summary>
public class UserClaimEntity : IdentityUserClaim<Guid>
{
    /// <summary>
    /// Role description
    /// </summary>
    public string? Description { get; set; }
}