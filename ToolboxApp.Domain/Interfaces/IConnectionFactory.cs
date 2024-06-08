using System.Data.Common;

namespace ToolboxApp.Data;

public interface IConnectionFactory
{
    public (DbConnection, Exception?) GetConnection(string connectionString, string providerName);
}