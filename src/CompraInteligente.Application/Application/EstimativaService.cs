using CompraInteligente.Domain.IApplication;
using CompraInteligente.Domain.IRepository;
using CompraInteligente.Domain.IServices;
using CompraInteligente.Domain.Entidade;
using System.Text.Json;
using CompraInteligente.Domain.Dto;

namespace CompraInteligente.Application;
public class EstimativaService : IEstimativaService
{
    private readonly IConfiguracaoService _configuracaoService;
    private readonly ICompraInteligenteLogRepository _LogRepository;
    private readonly ICompraInteligenteHistoricoRepository _historicoRepository;
    private readonly IWsChatGpt _WsChatGpt;

    public EstimativaService(IConfiguracaoService configuracaoService, ICompraInteligenteLogRepository logRepository, ICompraInteligenteHistoricoRepository historicoRepository, IWsChatGpt wsChatGpt)
    {
        _configuracaoService = configuracaoService;
        _historicoRepository = historicoRepository;
        _LogRepository = logRepository;
        _WsChatGpt = wsChatGpt;
    }

    public async Task<List<EstimativaDto>> GerarEstimativa(byte mes)
    {
        List<CompraInteligenteLog> log = new() { new("Inicio", $"Mês: {mes}") };
        try
        {
            _WsChatGpt.InjetarComfiguracao(_configuracaoService.ObterConfiguracao());
            var listHistorico = _historicoRepository.GetAll();
            log.Add(new("Histórico", $"QuantidadeHistórico: {listHistorico.Count}"));

            var dto = new List<EstimativaDto>();
            foreach (var HistoricoProduto in listHistorico.GroupBy(x => x.Produto).ToList())
            {
                try
                {
                    var produto = HistoricoProduto.First().Produto;
                    var Quantidade = await _WsChatGpt.EstimarGpt(JsonSerializer.Serialize(HistoricoProduto), mes);
                    await Task.Delay(100);
                    log.Add(new("Informação", $"Produto: {produto} || Quantidade: {Quantidade}"));
                    dto.Add(new(produto, short.Parse(Quantidade.Replace("\n", ""))));
                }
                catch (Exception)
                {

                }
            }

            log.Add(new("Estimativa", $"QuantidadeEstimativa: {dto.Count}"));
            log.Add(new("Fim", "Fim"));
            _LogRepository.SalvarLista(log);
            return dto;
        }
        catch (Exception ex)
        {
            log.Add(new("Erro", JsonSerializer.Serialize(ex)));
            _LogRepository.SalvarLista(log);
            throw;
        }
    }
}
