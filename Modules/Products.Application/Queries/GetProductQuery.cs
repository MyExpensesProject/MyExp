/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;
using Users.Domain.Entities;

namespace Products.Application.Queries
{
    /// <summary>
    /// Query
    /// </summary>
    public record GetProductQuery(string Email, string Password) : IRequest<UserEntity?>;

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, UserEntity?>
    {
        private readonly IApplicationDbContext _context;

        public GetProductQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var data = await _context.Users.FirstOrDefaultAsync(d =>
                    d.Email == query.Email
                    && d.Password == query.Password,
                cancellationToken: cancellationToken);

            return data;
        }
    }
}