using Microsoft.AspNetCore.Identity;

namespace User.Domain.Entities;

/// <summary>
/// Role entity
/// </summary>
public class UserRoleEntity : IdentityRole<Guid>
{
    /// <summary>
    /// Role description
    /// </summary>
    public string? Description { get; set; }
}