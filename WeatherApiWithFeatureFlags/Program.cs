using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureAppConfiguration(options => {
    var connectionString = builder.Configuration.GetConnectionString("AppConfig");
    options.Connect(connectionString).UseFeatureFlags();
});

builder.Services.AddAzureAppConfiguration();
builder.Services.AddFeatureManagement().AddFeatureFilter<WeekdayFilter>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAzureAppConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async (IFeatureManager featureManager, IConfiguration configuration) =>
{
    var isDetailed = await featureManager.IsEnabledAsync("DetailedWeatherForecast");

    // Get All Filters
    var featureFilters = configuration.GetSection("FeatureManagement:DetailedWeatherForecast").GetChildren().ToList();

    // Check for active filters
    var areFiltersActive = featureFilters.Any();

    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)],
            isDetailed ? $"Detailed data for day {index}" : null,
            areFiltersActive ? "Filter Active" : null
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary, string? Details, string? AppliedFilters)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

[FilterAlias("Weekday")]
public class WeekdayFilter : IFeatureFilter
{
    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
    {
        var today = DateTime.Now.DayOfWeek;
        bool isWeekday = today != DayOfWeek.Saturday && today != DayOfWeek.Sunday;
        return Task.FromResult(isWeekday);
    }
}
