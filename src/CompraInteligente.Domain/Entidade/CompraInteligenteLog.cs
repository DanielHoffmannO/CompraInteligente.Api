using Microsoft.EntityFrameworkCore;

namespace CompraInteligente.Domain.Entidade;

public class CompraInteligenteLog : Entity<CompraInteligenteLog, short>
{
    public CompraInteligenteLog() { }
    public CompraInteligenteLog(string descricao, string log)
    {
        Console.WriteLine($"{descricao}: {log}");
        this.Log = log.Length <= 600 ? log : log[..600];
        Descricao = descricao.Length <= 50 ? descricao : descricao[..600];
        Data = DateTime.Now;
    }

    public DateTime Data { get; set; }
    public string Descricao { get; set; }
    public string Log { get; set; }
}