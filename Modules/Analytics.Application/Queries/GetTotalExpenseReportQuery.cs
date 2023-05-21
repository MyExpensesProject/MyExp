/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;
using Users.Domain.Entities;

namespace Analytics.Application.Queries
{
    /// <summary>
    /// Query
    /// </summary>
    public record GetTotalExpenseReportQuery(string Email, string Password) : IRequest<UserEntity?>;

    public class GetTotalExpenseReportQueryHandler : IRequestHandler<GetTotalExpenseReportQuery, UserEntity?>
    {
        private readonly IApplicationDbContext _context;

        public GetTotalExpenseReportQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> Handle(GetTotalExpenseReportQuery query, CancellationToken cancellationToken)
        {
            var data = await _context.Users.FirstOrDefaultAsync(d =>
                    d.Email == query.Email
                    && d.Password == query.Password,
                cancellationToken: cancellationToken);

            return data;
        }
    }
}