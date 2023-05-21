﻿/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Expenses.Application.Queries.Note;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;
using Users.Domain.Entities;

namespace Expenses.Application.Queries.User
{
    /// <summary>
    /// Query
    /// </summary>
    public record GetUserIncomeQuery(string Email, string Password) : IRequest<UserEntity?>;

    public class GetUserIncomeQueryHandler : IRequestHandler<GetExpenseNotebookQuery, UserEntity?>
    {
        private readonly IApplicationDbContext _context;

        public GetUserIncomeQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> Handle(GetExpenseNotebookQuery query, CancellationToken cancellationToken)
        {
            var data = await _context.Users.FirstOrDefaultAsync(d =>
                    d.Email == query.Email
                    && d.Password == query.Password,
                cancellationToken: cancellationToken);

            return data;
        }
    }
}