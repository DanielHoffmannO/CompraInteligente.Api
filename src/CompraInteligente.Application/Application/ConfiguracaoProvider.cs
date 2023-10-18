using Microsoft.Extensions.DependencyInjection;
using CompraInteligente.Domain.Entidade;
using CompraInteligente.Domain.IApplication;
using CompraInteligente.Domain.IRepository;

namespace CompraInteligente.Application;
public class ConfiguracaoProvider : IConfiguracaoProvider
{
    private readonly IServiceProvider _serviceProvider;
    private CompraInteligenteConfiguracao SenhaGptConfiguracao { get; set; }
    public ConfiguracaoProvider(IServiceProvider repository)
    {
        _serviceProvider = repository;
        SenhaGptConfiguracao = ObterConfiguracaoRepository();
    }

    private CompraInteligenteConfiguracao ObterConfiguracaoRepository()
    {
        var ruleService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ICompraInteligenteConfiguracaoRepository>();
        return ruleService?.ObterConfiguracaoVigente() ?? new CompraInteligenteConfiguracao();
    }

    public CompraInteligenteConfiguracao ObterConfiguracao() => SenhaGptConfiguracao;

    public void RecarregarConfiguracao() => SenhaGptConfiguracao = ObterConfiguracaoRepository();
}
