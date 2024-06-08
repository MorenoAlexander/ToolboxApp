using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace ToolboxApp.Data;

public class SqlConnectionFactory(ILogger<SqlConnectionFactory> logger) : IConnectionFactory
{
    
    public (DbConnection, Exception?) GetConnection(string connectionString, string providerName)
    {
        logger.LogDebug("Creating new DBConnection instance for {ProviderName}", providerName);

        return (providerName) switch
        {
            "sqlserver" => (new SqlConnection(connectionString), null),
            _ => (null, new NotImplementedException($"Provider {providerName} not supported"))!
        };
    }
}