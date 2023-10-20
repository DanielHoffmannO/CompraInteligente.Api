﻿using CompraInteligente.Domain.IApplication;
using CompraInteligente.Domain.IRepository;
using CompraInteligente.Domain.Exceptions;
using CompraInteligente.Domain.Entidade;
using Mapster;
using CompraInteligente.Domain.Model;

namespace CompraInteligente.Application;
public class ConfiguracaoService : IConfiguracaoService
{
    public readonly ICompraInteligenteConfiguracaoRepository _senhaGptConfiguracaoRepository;
    public readonly IConfiguracaoProvider _configuracaoProvider;
    public ConfiguracaoService(ICompraInteligenteConfiguracaoRepository senhaGptConfiguracaoRepository, IConfiguracaoProvider configuracaoProvider)
    {
        _senhaGptConfiguracaoRepository = senhaGptConfiguracaoRepository;
        _configuracaoProvider = configuracaoProvider;
    }

    public CompraInteligenteConfiguracao ObterConfiguracao() =>
        _configuracaoProvider.ObterConfiguracao();

    public short AdicionarConfiguracao(ConfiguracaoModel model)
    {
        var Configuracao = model.Adapt<CompraInteligenteConfiguracao>();
        Configuracao.DataCadastro = DateTime.Now;

        FinalizarConfiguracaoAnterior();
        if (_senhaGptConfiguracaoRepository.Salvar(Configuracao))
        { 

            _configuracaoProvider.RecarregarConfiguracao();
            return _senhaGptConfiguracaoRepository.ObterUltimaConfiguracao()?.Id ?? 0;
        }
        throw new SqlException("Erro ao salvar configuração no banco.");
    }

    private void FinalizarConfiguracaoAnterior()
    {
        var Configuracao = _senhaGptConfiguracaoRepository.ObterUltimaConfiguracao();
        if (Configuracao is not null)
        {
            Configuracao.DataVigencia = DateTime.Now;
            _senhaGptConfiguracaoRepository.Atualizar(Configuracao);
        }
    }
}
