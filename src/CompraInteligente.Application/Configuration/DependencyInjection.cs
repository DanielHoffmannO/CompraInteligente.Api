using Microsoft.Extensions.DependencyInjection;
using CompraInteligente.Domain.IApplication;

namespace CompraInteligente.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
        => services.AddScoped<ICompraInteligenteRepository, SenhaService>()
                   .AddScoped<IConfiguracaoService, ConfiguracaoService>()
                   .AddSingleton<IConfiguracaoProvider, ConfiguracaoProvider>();
}
