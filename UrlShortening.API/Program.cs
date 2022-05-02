global using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure.Data.SQL;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
//add this

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();

builder.Services.AddDbContext<UrlContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IUrlRepository, UrlRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseFastEndpoints(options =>
{
    options.RoutingOptions = routingOptions
        =>
    {
        routingOptions.Prefix = "api";
    };
});
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.MapControllers();
app.Run();