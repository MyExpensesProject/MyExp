using Expenses.Domain.Entities.Note;
using Microsoft.EntityFrameworkCore;

namespace Shared.Migrations.Relationships;

internal class ConfigureRelationship
{
    protected internal static void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseNotebookEntity>()
            .HasMany(c => c.ExpenseNotes)
            .WithOne(e => e.ExpenseNotebook);
    }
}