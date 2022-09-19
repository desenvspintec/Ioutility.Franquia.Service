using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Ioutility.Franquias.Repository.Franquias.Maps;
using Ioutility.Franquias.Repository.Procedimentos.Maps;
using Microsoft.EntityFrameworkCore;
using Pulsati.Core.Domain.EventSources;
using Pulsati.Core.Repository.ContextMaps;

namespace Ioutility.Franquias.Repository.DbContexts
{
    public class FranquiaDb : DbContext
    {
        public FranquiaDb(DbContextOptions<FranquiaDb> options) : base(options)
        {
        }

        public DbSet<EventSource> EventsSources { get; set; }
        public DbSet<Franquia> Franquias { get; set; }

        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<TipoProcedimento> TiposProcedimentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityMap<EventSource>());
            modelBuilder.ApplyConfiguration(new FranquiaMap());
            modelBuilder.ApplyConfiguration(new ProcedimentoMap());
            modelBuilder.ApplyConfiguration(new TipoProcedimentoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
