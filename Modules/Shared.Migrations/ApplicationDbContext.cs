using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace Shared.Migrations;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserClaimEntity> UserClaims { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserRolesEntity> UserRoles { get; set; }
    
    public new async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
}