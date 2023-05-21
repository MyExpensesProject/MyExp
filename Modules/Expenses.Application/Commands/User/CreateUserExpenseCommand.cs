/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.Security.Claims;
using Expenses.Domain.Dto.User;
using Expenses.Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Migrations;

namespace Expenses.Application.Commands.User;

public record CreateUserExpenseCommand(UserExpensesDto Dto) : IRequest<UserExpensesEntity>;

public class CreateUserExpenseCommandHandler : IRequestHandler<CreateUserExpenseCommand, UserExpensesEntity>
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateUserExpenseCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<UserExpensesEntity> Handle(CreateUserExpenseCommand command, CancellationToken cancellationToken)
    {
        if (command.Dto is null)
            throw new Exception();

        var userId = Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var entity = new UserExpensesEntity
        {
            Id = Guid.NewGuid(),

            UserId = userId,
            ExpenseType = command.Dto.ExpenseType,
            Amount = command.Dto.Amount,

            CreatedById = userId,
            CreateDate = DateTime.Now,
            UpdateById = userId,
            UpdateDate = DateTime.Now,
            IsDeleted = false
        };

        var result = await _context.UserExpenses.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync();

        return result.Entity;
    }
}