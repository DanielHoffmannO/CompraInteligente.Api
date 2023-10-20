using CompraInteligente.Persistence.Context;
using CompraInteligente.Domain.IRepository;
using CompraInteligente.Domain.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CompraInteligente.Persistence.Repositories;

public class CompraInteligenteConfiguracaoRepository : Repository<CompraInteligenteConfiguracao, short>, ICompraInteligenteConfiguracaoRepository
{
    public CompraInteligenteConfiguracaoRepository(CompraInteligenteContext context) : base(context)
    {
    }

    public CompraInteligenteConfiguracao ObterConfiguracaoVigente() =>
        DbSet.FirstOrDefault(x => x.DataVigencia == null) ?? new();

    public CompraInteligenteConfiguracao ObterUltimaConfiguracao() =>
        DbSet.OrderByDescending(x => x.Id).FirstOrDefault();

    public bool Salvar(CompraInteligenteConfiguracao config)
    {
        Db.Add(config);
        return Db.Commit();
    }

    public bool Atualizar(CompraInteligenteConfiguracao config)
    {
        Db.Update(config);
        return Db.Commit();
    }
}
