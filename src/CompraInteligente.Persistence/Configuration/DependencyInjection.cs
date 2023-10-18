using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CompraInteligente.Persistence.Repositories;
using Senha.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using CompraInteligente.Persistence.Context;
using CompraInteligente.Domain.IRepository;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CompraInteligente.Persistence.Configuration;
public static class DependencyInjection
{
    public static IServiceCollection RegisterPersistence(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<CompraInteligenteContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CompraInteligenteConnection"));
#if DEBUG
            var loggerFactory = new LoggerFactory().AddSerilog(Log.Logger);
            options.UseLoggerFactory(loggerFactory);
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
#endif
        }).RegisterRepositories();

    public static IServiceCollection RegisterRepositories(this IServiceCollection services) =>
        services.AddScoped<ICompraInteligenteConfiguracaoRepository, SenhaGptConfiguracaoRepository>()
                .AddScoped<ISenhaRepository, SenhaRepository>()
                .AddScoped<ICompraInteligenteLogRepository, SenhaGptLogRepository>();
}
