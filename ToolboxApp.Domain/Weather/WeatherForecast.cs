namespace ToolboxApp.Domain.Weather;

public record WeatherForecast
{
    public DateOnly Date;
    public int TemperatureC;
    public string? Summary;
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}