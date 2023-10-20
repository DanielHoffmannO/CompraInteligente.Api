using Microsoft.EntityFrameworkCore;
using CompraInteligente.Persistence.Context;
using CompraInteligente.Domain.IRepository;
using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Persistence.Repositories;

public class CompraInteligenteHistoricoRepository : Repository<CompraInteligenteHistorico, short>, ICompraInteligenteHistoricoRepository
{
    public CompraInteligenteHistoricoRepository(CompraInteligenteContext context) : base(context)
    {
    }

    public List<CompraInteligenteHistorico> GetAll() => DbSet.ToList();
}
