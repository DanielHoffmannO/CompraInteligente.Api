using Microsoft.EntityFrameworkCore;

namespace CompraInteligente.Domain.Entidade;
public class CompraInteligenteConfiguracao : Entity<CompraInteligenteConfiguracao, short>
{
    public string EmailCadastro { get; set; }
    public string ChaveAcesso { get; set; }
    public string UrlBase { get; set; }
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataVigencia { get; set; }

    public void Atualizar(string emailCadastro, string chaveAcesso, string urlBase)
    {
        EmailCadastro = emailCadastro;
        ChaveAcesso = chaveAcesso;
        UrlBase = urlBase;
    }
}
