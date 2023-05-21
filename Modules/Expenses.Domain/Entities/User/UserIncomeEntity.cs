using Shared.Core.Entities;
using Shared.Core.Enums;

namespace Expenses.Domain.Entities.User;

/// <summary>
/// User expenses entity
/// </summary>
public class UserIncomeEntity : IBaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// User id
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Expense type
    /// </summary>
    public IncomeType ExpenseType { get; set; }
    
    /// <summary>
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Id created user
    /// </summary>
    public Guid CreatedById { get; set; }

    /// <summary>
    /// Created date
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Id updated user
    /// </summary>
    public Guid UpdateById { get; set; }

    /// <summary>
    /// Update date
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Is deleted flag
    /// </summary>
    public bool IsDeleted { get; set; }
}