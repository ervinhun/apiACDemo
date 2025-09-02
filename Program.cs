using apiACDemo;
using NSwag;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Aircraft";
    config.Version = "v1.0.0.0";
    config.Description = "Aircraft API";
});
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddScoped<AircraftService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>();
OpenApiHeader header = new OpenApiHeader();
header.Name = "Authorization";
header.Description = "Authorization token";


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<MyDbContext>().Database.EnsureCreated();
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/values", () => new[] { "value1", "value2" });

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();
app.Run();
