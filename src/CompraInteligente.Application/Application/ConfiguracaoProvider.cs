﻿using Microsoft.Extensions.DependencyInjection;
using CompraInteligente.Domain.IApplication;
using CompraInteligente.Domain.IRepository;
using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Application;

public class ConfiguracaoProvider : IConfiguracaoProvider
{
    private readonly IServiceProvider _serviceProvider;
    private CompraInteligenteConfiguracao _configuracao { get; set; }
    public ConfiguracaoProvider(IServiceProvider repository)
    {
        _serviceProvider = repository;
        _configuracao = ObterConfiguracaoRepository();
    }

    private CompraInteligenteConfiguracao ObterConfiguracaoRepository()
    {
        var ruleService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ICompraInteligenteConfiguracaoRepository>();
        return ruleService?.ObterConfiguracaoVigente() ?? new CompraInteligenteConfiguracao();
    }

    public CompraInteligenteConfiguracao ObterConfiguracao() => _configuracao;

    public void RecarregarConfiguracao() => _configuracao = ObterConfiguracaoRepository();
}
