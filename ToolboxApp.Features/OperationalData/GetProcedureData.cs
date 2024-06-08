using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using ToolboxApp.Data;
using ToolboxApp.Domain.OperationalData;

namespace ToolboxApp.Features.OperationalData;

public static class GetProcedureData
{
    public record GetProcedureDataCommand(string ProcedureName) : IRequest<IEnumerable<StoredProcedureInfo>>;

    public class GetProcedureDataHandler(IConnectionFactory dbConnectionFactory, IConfiguration configuration) : IRequestHandler<GetProcedureDataCommand, IEnumerable<StoredProcedureInfo>>
    {
        public Task<IEnumerable<StoredProcedureInfo>> Handle(GetProcedureDataCommand request, CancellationToken cancellationToken)
        {
            var (dbConnection, exception) =
                dbConnectionFactory.GetConnection(configuration.GetConnectionString("DefaultConnection"), "sqlserver");
            if (exception is not null)
            {
                throw exception;
            }

            using var connection = dbConnection;
            var query = @"
SELECT 
    SPECIFIC_NAME AS ProcedureName,
    PARAMETER_NAME AS ParameterName,
    ORDINAL_POSITION AS OrdinalPosition,
    PARAMETER_MODE AS ParameterMode,
    CHARACTER_MAXIMUM_LENGTH AS MaxLength
FROM INFORMATION_SCHEMA.PARAMETERS
WHERE SPECIFIC_NAME = @ProcedureName;
";

                var result = connection.Query<StoredProcedureInfo>(query, new { ProcedureName = request.ProcedureName });
                return Task.FromResult(result);
        }
    }
}