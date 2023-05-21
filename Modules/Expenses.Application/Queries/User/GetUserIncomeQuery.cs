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
    public record GetUserIncomeQuery(string Email, string Password) : IRequest<IEnumerable<UserIncomeDto>?>;

    public class GetUserIncomeQueryHandler : IRequestHandler<GetUserIncomeQuery, IEnumerable<UserIncomeDto>?>
    {
        private readonly IDapperContext _dapperContext;

        public GetUserIncomeQueryHandler(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<UserIncomeDto>?> Handle(GetUserIncomeQuery query, CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"SELECT /**select**/ FROM ""UserIncomes"" /**where**/ /**orderby**/");

            builder.Select("*");
            builder.OrderBy(@"""CreateDate"" desc");

            return await _dapperContext.CreateConnection().QueryAsync<UserIncomeDto>(template.RawSql, template.Parameters);
        }
    }
}