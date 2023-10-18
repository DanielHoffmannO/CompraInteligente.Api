using Microsoft.EntityFrameworkCore;
using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Domain.IRepository;
public interface ICompraInteligenteLogRepository : IRepository<CompraInteligenteLog, short>
{
    void SalvarLista(List<CompraInteligenteLog> senhaGptLog);
}
