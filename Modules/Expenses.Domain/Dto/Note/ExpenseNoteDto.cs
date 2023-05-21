using Expenses.Domain.Entities.Note;
using Shared.Core.Entities;
using Shared.Core.Enums;

namespace Expenses.Domain.Dto.Note;

/// <summary>
/// Product entity
/// </summary>
public class ExpenseNoteDto : IBaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Date
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Product id
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Unit
    /// </summary>
    public UnitTypeEnum Unit { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Notebook id
    /// </summary>
    public Guid ExpenseNotebookId { get; set; }

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