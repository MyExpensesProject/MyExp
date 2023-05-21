using Shared.Core.Entities;

namespace Expenses.Domain.Dto.Note;

/// <summary>
/// Notebook entity
/// </summary>
public class ExpenseNotebookDto : IBaseEntity
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
    /// Name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Image path
    /// </summary>
    public string ImagePath { get; set; }

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