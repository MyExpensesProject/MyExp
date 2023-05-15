using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;
#pragma warning disable CS8618
#pragma warning disable CS0108, CS0114

namespace Shared.Migrations;

public class ApplicationDbContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserClaimEntity> UserClaims { get; set; }
    public DbSet<UserRoleEntity> Roles { get; set; }
    public DbSet<UserRolesEntity> UserRoles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        RenameIdentityTables(builder);
    }

    private void RenameIdentityTables(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.HasDefaultSchema("public");
        
        builder.Entity<UserEntity>(entity =>
        {
            entity.ToTable(name: "Users");
        });
        
        builder.Entity<UserRoleEntity>(entity =>
        {
            entity.ToTable(name: "Roles");
        });
        
        builder.Entity<UserRolesEntity>(entity =>
        {
            entity.ToTable("UserRoles");
        });
        
        builder.Entity<UserClaimEntity>(entity =>
        {
            entity.ToTable("UserClaims");
        });
        
        builder.Entity<IdentityUserLogin<Guid>>(entity =>
        {
            entity.ToTable("UserLogins");
        });
        
        builder.Entity<IdentityRoleClaim<Guid>>(entity =>
        {
            entity.ToTable("RoleClaims");
        });
        
        builder.Entity<IdentityUserToken<Guid>>(entity =>
        {
            entity.ToTable("UserTokens");
        });
    }
    
    public new async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
}