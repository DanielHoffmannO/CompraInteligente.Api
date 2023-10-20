using CompraInteligente.Domain.IApplication;
using CompraInteligente.Domain.IRepository;
using CompraInteligente.Domain.IServices;
using CompraInteligente.Domain.Entidade;
using CompraInteligente.Domain.Dto;
using System.Text.Json;

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
        List<CompraInteligenteLog> log = new() { new("PayLoad", $"Mês: {mes}/{DateTime.Now.Year + 1}") };
        try
        {
            var listHistorico = _historicoRepository.GetAll();
            _WsChatGpt.InjetarComfiguracao(_configuracaoService.ObterConfiguracao());
            log.Add(new("Histórico", $"QuantidadeHistórico: {listHistorico.Count}"));

            var dto = new List<EstimativaDto>();
            foreach (var HistoricoProduto in listHistorico.GroupBy(x => x.Produto).ToList())
            {
                var produto = HistoricoProduto.First().Produto;
                var quantidade = await _WsChatGpt.EstimarGpt(JsonSerializer.Serialize(HistoricoProduto.Where(x => x.DataCadastro.Month == mes)), mes);
                await Task.Delay(100);
                log.Add(new("Informação", $"Produto: {produto} || Quantidade: {quantidade}"));
                dto.Add(new(produto, quantidade));
            }

            log.Add(new("Estimativa", $"QuantidadeEstimativa: {dto.Count}"));
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
