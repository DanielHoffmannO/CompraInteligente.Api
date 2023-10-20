using CompraInteligente.Persistence.Context;
using CompraInteligente.Domain.IRepository;
using CompraInteligente.Domain.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CompraInteligente.Persistence.Repositories;

public class CompraInteligenteLogRepository : Repository<CompraInteligenteLog, short>, ICompraInteligenteLogRepository
{
    public CompraInteligenteLogRepository(CompraInteligenteContext context) : base(context)
    {
    }

    public void SalvarLista(List<CompraInteligenteLog> senhaGptLog)
    {
        Db.AddRange(senhaGptLog);
        Db.Commit();
    }
}