namespace ToolboxApp.Data;

public static class Queries
{
    public const string GET_SP_DATA = @"
SELECT 
    SPECIFIC_NAME AS ProcedureName,
    PARAMETER_NAME AS ParameterName,
    ORDINAL_POSITION AS OrdinalPosition,
    PARAMETER_MODE AS ParameterMode,
    CHARACTER_MAXIMUM_LENGTH AS MaxLength
FROM INFORMATION_SCHEMA.PARAMETERS
WHERE SPECIFIC_NAME = @ProcedureName;
";
}