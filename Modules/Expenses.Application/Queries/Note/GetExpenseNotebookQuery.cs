/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Dapper;
using Expenses.Domain.Dto.Note;
using MediatR;
using Shared.Migrations;

namespace Expenses.Application.Queries.Note;

public record GetExpenseNotebookQuery(
    string Email,
    string Password
) : IRequest<IEnumerable<ExpenseNotebookDto>?>;

public class GetExpenseNotebookQueryHandler : IRequestHandler<GetExpenseNotebookQuery, IEnumerable<ExpenseNotebookDto>?>
{
    private readonly IDapperContext _dapperContext;

    public GetExpenseNotebookQueryHandler(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<ExpenseNotebookDto>?> Handle(GetExpenseNotebookQuery query,
        CancellationToken cancellationToken)
    {
        var builder = new SqlBuilder();
        var template = builder.AddTemplate(@"SELECT /**select**/ FROM ""ExpenseNotes"" /**where**/ /**orderby**/");

        builder
            .Select("*")
            .Where(@"")
            .OrderBy(@"""CreateDate"" desc");

        return await _dapperContext.CreateConnection()
            .QueryAsync<ExpenseNotebookDto>(template.RawSql, template.Parameters);
    }
}