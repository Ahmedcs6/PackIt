using PackIT.Application;
using PackIT.Infrastructure;
using PackIT.Shared;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddShared();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();
app.MapOpenApi();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Swagger"));
app.UseHttpsRedirection();
app.UseShared();
app.MapControllers();

app.Run();
