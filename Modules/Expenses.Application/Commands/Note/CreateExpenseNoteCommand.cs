/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.Security.Claims;
using Expenses.Domain.Dto.Note;
using Expenses.Domain.Entities.Note;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Migrations;

namespace Expenses.Application.Commands.Note;

public record CreateExpenseNoteCommand(ExpenseNoteDto Dto) : IRequest<ExpenseNoteEntity>;

public class CreateExpenseNoteCommandHandler : IRequestHandler<CreateExpenseNoteCommand, ExpenseNoteEntity>
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateExpenseNoteCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ExpenseNoteEntity> Handle(CreateExpenseNoteCommand command, CancellationToken cancellationToken)
    {
        if (command.Dto is null)
            throw new Exception();
        
        var userId = Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var entity = new ExpenseNoteEntity
        {
            Id = Guid.NewGuid(),
            
            Date = command.Dto.Date,
            ProductId = command.Dto.ProductId,
            Amount = command.Dto.Amount,
            Unit = command.Dto.Unit,
            Quantity = command.Dto.Quantity,
            ExpenseNotebookId = command.Dto.ExpenseNotebookId,

            CreatedById = userId,
            CreateDate = DateTime.Now,
            UpdateById = userId,
            UpdateDate = DateTime.Now,
            IsDeleted = false
        };

        var result = await _context.ExpenseNotes.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync();

        return result.Entity;
    }
}