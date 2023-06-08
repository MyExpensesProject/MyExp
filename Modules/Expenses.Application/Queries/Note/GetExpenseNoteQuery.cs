/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Dapper;
using Expenses.Domain.Dto.Note;
using MediatR;
using Shared.Migrations;

namespace Expenses.Application.Queries.Note;

public record GetExpenseNoteQuery(
    string Email,
    string Password
) : IRequest<IEnumerable<ExpenseNoteDto>?>;

public class GetExpenseNoteQueryHandler : IRequestHandler<GetExpenseNoteQuery, IEnumerable<ExpenseNoteDto>?>
{
    private readonly IDapperContext _dapperContext;

    public GetExpenseNoteQueryHandler(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<ExpenseNoteDto>?> Handle(GetExpenseNoteQuery query,
        CancellationToken cancellationToken)
    {
        var builder = new SqlBuilder();
        var template = builder.AddTemplate(@"SELECT /**select**/ FROM ""ExpenseNotes"" /**where**/ /**orderby**/");

        builder.Select("*");
        builder.OrderBy(@"""CreateDate"" desc");

        return await _dapperContext.CreateConnection().QueryAsync<ExpenseNoteDto>(template.RawSql, template.Parameters);
    }
}