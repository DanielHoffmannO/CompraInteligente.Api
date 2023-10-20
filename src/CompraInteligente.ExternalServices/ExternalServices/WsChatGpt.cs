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

    public async Task<string> EstimarGpt(string json, byte mes)
    {
        try
        {
            var requestData = new
            {
                model = "text-davinci-003",
                prompt = $@"Isso é uma requisicao de back-end por isso DEVE ME ENVIAR APENAS UM NUMERO 
                            Com base no Json enviado {json}, 
                            me forneça uma nova suposição da
                            quantidade do produto que será comprada 
                            em {mes}/{DateTime.Now.Year + 1}. 
                            A estimativa deve considerar os dados
                            fornecidos no JSON e levar em conta 
                            uma possível tendência anual de aumento ou diminuição.",
                max_tokens = 50,
                temperature = 1,
            };

            var response = await _httpClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var responseObject = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                return responseObject?.choices[0].text ?? "";
            }

            return "5";
            throw new GptException("Erro ao integrar com chat gpt.");
        }
        catch (Exception)
        {
            return "5";
            throw new GptException("Erro ao integrar com chat gpt.");
        }
    }
}
