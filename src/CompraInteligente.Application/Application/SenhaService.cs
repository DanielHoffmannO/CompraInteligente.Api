﻿using CompraInteligente.Domain.IApplication;
using CompraInteligente.Domain.IRepository;
using CompraInteligente.Domain.IServices;
using CompraInteligente.Domain.Entidade;
using System.Text.Json;

namespace CompraInteligente.Application;
public class SenhaService : ICompraInteligenteRepository
{
    private readonly IConfiguracaoService _configuracaoService;
    private readonly ICompraInteligenteLogRepository _senhaGptLogRepository;
    private readonly ISenhaRepository _SenhaRepository;
    private readonly IWsChatGpt _WsChatGpt;

    public SenhaService(IConfiguracaoService configuracaoService, ICompraInteligenteLogRepository senhaGptLogRepository, ISenhaRepository SenhaRepository, IWsChatGpt wsChatGpt)
    {
        _configuracaoService = configuracaoService;
        _senhaGptLogRepository = senhaGptLogRepository;
        _SenhaRepository = SenhaRepository;
        _WsChatGpt = wsChatGpt;
    }

    public async Task<SenhaGpt> CriarNovaSenha(string PalavraChave)
    {
        List<CompraInteligenteLog> log = new() { new("Inicio", $"PalavraChave: {PalavraChave}") };
        var senha = new SenhaGpt(PalavraChave);
        try
        {
            var responce = await IntegracaoChatGpt(PalavraChave);
            log.Add(new("ChatGpt", responce));

            senha.ConcatenarPalavras(responce);
            log.Add(new("ConcatenarPalavras", senha.SenhaGerada));

            senha.AumentarComplexidade();
            log.Add(new("SenhaComplexa", senha.SenhaGerada));

            senha.AdicionarNumerais();
            log.Add(new("SenhaFinal", senha.SenhaGerada));

            if (!_SenhaRepository.Salvar(senha))
                throw new("Erro ao obter senha");

            _senhaGptLogRepository.SalvarLista(log);
            return senha;
        }
        catch (Exception ex)
        {
            log.Add(new("Erro", JsonSerializer.Serialize(ex)));
            _senhaGptLogRepository.SalvarLista(log);
            throw;
        }
    }

    private async Task<string> IntegracaoChatGpt(string PalavraChave)
    {
        _WsChatGpt.InjetarComfiguracao(_configuracaoService.ObterConfiguracao());
        return await _WsChatGpt.ObterPalavrasSimilares(PalavraChave);
    }
}
