using Expenses.Domain.Entities.Note;
using Expenses.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Users.Domain.Entities;

namespace Shared.Migrations;

/// <summary>
/// Application db context interface
/// </summary>
public interface IApplicationDbContext
{
    /// <summary>
    /// Users
    /// </summary>
    public DbSet<UserEntity> Users { get; set; }
    
    /// <summary>
    /// User claims
    /// </summary>
    public DbSet<UserClaimEntity> UserClaims { get; set; }
    
    /// <summary>
    /// Roles
    /// </summary>
    public DbSet<RoleEntity> Roles { get; set; }
    
    /// <summary>
    /// User roles
    /// </summary>
    public DbSet<UserRolesEntity> UserRoles { get; set; }
    
    /// <summary>
    /// Expenses notebooks
    /// </summary>
    public DbSet<ExpenseNotebookEntity> ExpenseNotebooks { get; set; }

    /// <summary>
    /// Expense notes
    /// </summary>
    public DbSet<ExpenseNoteEntity> ExpenseNotes { get; set; }
    
    /// <summary>
    /// Products
    /// </summary>
    public DbSet<ProductEntity> Products { get; set; }
    
    /// <summary>
    /// User expenses
    /// </summary>
    public DbSet<UserExpensesEntity> UserExpenses { get; set; }
    
    /// <summary>
    /// User incomes
    /// </summary>
    public DbSet<UserIncomeEntity> UserIncomes { get; set; }
    
    /// <summary>
    /// Save changes async
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync();
}