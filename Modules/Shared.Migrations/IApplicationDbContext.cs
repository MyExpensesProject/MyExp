using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace Shared.Migrations;

public interface IApplicationDbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserClaimEntity> UserClaims { get; set; }
    public DbSet<UserRoleEntity> Roles { get; set; }
    public DbSet<UserRolesEntity> UserRoles { get; set; }
    
    Task<int> SaveChanges();
}