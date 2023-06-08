/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Dapper;
using Expenses.Domain.Dto.User;
using MediatR;
using Shared.Migrations;

namespace Expenses.Application.Queries.User
{
    /// <summary>
    /// Query
    /// </summary>
    public record GetUserExpensesQuery(string Email, string Password) : IRequest<IEnumerable<UserExpensesDto>?>;

    public class GetUserExpensesQueryHandler : IRequestHandler<GetUserExpensesQuery, IEnumerable<UserExpensesDto>?>
    {
        private readonly IDapperContext _dapperContext;

        public GetUserExpensesQueryHandler(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<UserExpensesDto>?> Handle(GetUserExpensesQuery query, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"SELECT /**select**/ FROM ""UserExpenses"" /**where**/ /**orderby**/");

            builder.Select("*");
            builder.OrderBy(@"""CreateDate"" desc");

            return await _dapperContext.CreateConnection().QueryAsync<UserExpensesDto>(template.RawSql, template.Parameters);
        }
    }
}