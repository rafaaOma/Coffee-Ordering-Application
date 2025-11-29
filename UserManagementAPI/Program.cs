var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();// Add services for controllers
builder.Services.AddScoped<IUserService, UserService>(); // Register UserService 
builder.Logging.AddConsole();//add console logging 

var app = builder.Build();
//Middleware registration
app.UseMiddleware<GlobalMiddleware>();//first middleware to handle global exceptions
app.UseMiddleware<UserManagement.Middlewares.AuthenticationMiddleware>();//second middleware to authenticate requests
app.UseMiddleware<UserManagement.Middlewares.LoggingMiddleware>();//third middleware to log requests & responses
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();   // Map attribute routes
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
