using CompraInteligente.Domain.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CompraInteligente.Domain.IRepository;

public interface ICompraInteligenteHistoricoRepository : IRepository<CompraInteligenteHistorico, short>
{
    List<CompraInteligenteHistorico> GetAll();
}
