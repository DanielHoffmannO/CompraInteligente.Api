using CompraInteligente.Domain.IApplication;
using Microsoft.AspNetCore.Mvc;
using CompraInteligente.Domain.Model;

namespace CompraInteligente.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfiguracaoController : ControllerBase
{
    private readonly IConfiguracaoService _configuracaoService;

    public ConfiguracaoController(IConfiguracaoService configuracaoService)
    {
        _configuracaoService = configuracaoService;
    }

    /// <summary>
    /// Obtém uma lista de Configuração do ChatGpt.
    /// </summary>
    [HttpGet]
    public IActionResult Obter() => Ok(_configuracaoService.ObterConfiguracao());

    /// <summary>
    /// Adiciona uma nova Configuração do ChatGpt.
    /// </summary>
    /// <param name="model">Informações da Configuração a ser adicionado.</param>
    [HttpPost]
    public IActionResult Adicionar(ConfiguracaoModel model)
    {
        return Ok(_configuracaoService.AdicionarConfiguracao(model));
    }
}