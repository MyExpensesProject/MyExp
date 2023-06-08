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

public record CreateExpenseNotebookCommand(ExpenseNotebookDto Dto) : IRequest<ExpenseNotebookEntity>;

public class CreateExpenseNotebookCommandHandler : IRequestHandler<CreateExpenseNotebookCommand, ExpenseNotebookEntity>
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateExpenseNotebookCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ExpenseNotebookEntity> Handle(CreateExpenseNotebookCommand command, CancellationToken cancellationToken)
    {
        if (command.Dto is null)
            throw new Exception();
        
        var userId = Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var entity = new ExpenseNotebookEntity
        {
            Id = Guid.NewGuid(),

            UserId = userId,
            Name = command.Dto.Name,
            Description = command.Dto.Description,
            ImagePath = command.Dto.ImagePath,
            
            CreatedById = userId,
            CreateDate = DateTime.Now,
            UpdateById = userId,
            UpdateDate = DateTime.Now,
            IsDeleted = false
        };

        var result = await _context.ExpenseNotebooks.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync();

        return result.Entity;
    }
}