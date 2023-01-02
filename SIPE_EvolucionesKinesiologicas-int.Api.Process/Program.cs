using SIPE_Evolucion.Application;
using SIPE_Evolucion.Infrastructure;
using Serilog;
using SIPE_Evolucion.Application.Common.Mapper;
using SIPE_Evolucion.Application.Common.Filters;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host
    .UseSerilog(((ctx, lc) => 
    lc.ReadFrom.Configuration(ctx.Configuration)));

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);


// Add FluentValidation
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
    options.EnableEndpointRouting = false;
}).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapperServices();
// Factory: AutoMapper
var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIPE_Evolucion.Api.Process v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
