using CompraInteligente.Domain.Exceptions;
using CompraInteligente.Domain.IServices;
using CompraInteligente.Domain.Entidade;
using Newtonsoft.Json;
using System.Text;

namespace CompraInteligente.ExternalServices;

public class WsChatGpt : IWsChatGpt
{
    private readonly HttpClient _httpClient;

    public WsChatGpt(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void InjetarComfiguracao(CompraInteligenteConfiguracao config)
    {
        _httpClient.BaseAddress = new Uri(config.UrlBase);
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {config.ChaveAcesso}");
    }

    public async Task<byte> EstimarGpt(string json, byte mes)
    {
        try
        {
            string prompt = $@"Me Forneça apenas um numero da suposição numérica da quantidade 
                    do produto que será comprada apenas na data {mes}/{DateTime.Now.Year + 1}. A suposição 
                    deve considerar os dados fornecidos no JSON {json}e levar em conta uma possível 
                    tendência anual de aumento ou diminuição.";

            var requestData = new
            {
                model = "text-davinci-003",
                prompt = prompt,
                max_tokens = 10,
                temperature = 1,
            };

            var response = await _httpClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                    var retorno = $"{responseObject?.choices[0].text ?? ""}";
                    return byte.Parse(retorno.Where(char.IsDigit).ToArray());
                }
                catch (Exception)
                {
                    return 5;
                }
            }

            throw new GptException("Erro ao integrar com chat gpt.");
        }
        catch (Exception)
        {
            throw new GptException("Erro ao integrar com chat gpt.");
        }
    }
}
