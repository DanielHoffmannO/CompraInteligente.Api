﻿using Microsoft.AspNetCore.Mvc;
using CompraInteligente.Domain.Model;
using CompraInteligente.Domain.IApplication;

namespace CompraInteligente.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EstimativaController : ControllerBase
{
    private readonly IEstimativaService _estimativaService;

    public EstimativaController(IEstimativaService estimativaService)
    {
        _estimativaService = estimativaService;
    }

    /// <summary>
    /// Obtém uma lista de Configuração do ChatGpt.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Gerar(byte mes) => Ok(await _estimativaService.GerarEstimativa(mes));

}