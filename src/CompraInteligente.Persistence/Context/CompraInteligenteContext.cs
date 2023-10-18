using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CompraInteligente.Persistence.Context;

public class CompraInteligenteContext : AbstractContext
{
    public CompraInteligenteContext(DbContextOptions<CompraInteligenteContext> options) : base(options) { }

    protected override Assembly GetConfigurationAssembly()
        => GetType().Assembly;

    protected override Func<Type, bool> GetConfigurationTypePredicate()
        => type => type.Namespace != null && type.Namespace.EndsWith("Mappings.CompraInteligente");
}

