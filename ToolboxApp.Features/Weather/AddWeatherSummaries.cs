using Dapper;
using MediatR;
using ToolboxApp.Data;

namespace ToolboxApp.Features.Weather;

public class AddWeatherSummaries
{
    public record AddWeatherForecastsCommand(string Summary) : IRequest;


    public class AddWeatherForecastsCommandHandler(IConnectionFactory connectionFactory) : IRequestHandler<AddWeatherForecastsCommand>
    {
        public Task Handle(AddWeatherForecastsCommand request, CancellationToken cancellationToken)
        {
            var (dbConnection, exception) = connectionFactory.GetConnection("DefaultConnection", "sqlserver");
            if (exception is not null)
            {
                return Task.FromException(exception);
            }
            
            using var connection = dbConnection;
            var query = @"INSERT INTO WEATHER_SUMMARY (Summary) VALUES (@Summary);";
            connection.Execute(query, new { Summary = request.Summary });
            
            return Task.CompletedTask;
        }
    }
}