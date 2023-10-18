using CompraInteligente.ExternalServices.Configuration;
using CompraInteligente.Application.Configuration;
using CompraInteligente.Persistence.Configuration;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.Host.UseSerilog((hostingContext, services, loggerConfiguration) =>
{
    loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext();
});

services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
services.AddHealthChecks();
services.AddMvc().AddXmlDataContractSerializerFormatters();

/* AUTHENTICATION */
services.AddHttpContextAccessor();

services.AddAuthentication();
services.AddAuthorization();

services.AddAuthorization();
services.AddMemoryCache();
/* AUTHENTICATION */

/* IOC */
services.RegisterApplication();
services.RegisterPersistence(builder.Configuration);
services.RegisterExternalServices();
/* IOC */

/* SWAGGER */
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Senha API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Compra Inteligente Api V1");
        c.RoutePrefix = "swagger";
    });
}
/* SWAGGER */

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
    endpoints.MapControllers();
});

app.Run();