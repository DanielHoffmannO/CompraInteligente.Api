using Microsoft.Extensions.DependencyInjection;
using CompraInteligente.Domain.IApplication;

namespace CompraInteligente.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
        => services.AddScoped<IEstimativaService, EstimativaService>()
                   .AddScoped<IConfiguracaoService, ConfiguracaoService>()
                   .AddSingleton<IConfiguracaoProvider, ConfiguracaoProvider>();
}
