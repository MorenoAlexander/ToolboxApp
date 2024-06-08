namespace ToolboxApp.Domain.OperationalData;

public record StoredProcedureInfo(
    string ProcedureName,
    string ParameterName,
    int OrdinalPosition,
    string ParameterMode,
    int MaxLength);