using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Repository.Franquias.Maps;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityMap<EventSource>());
            modelBuilder.ApplyConfiguration(new FranquiaMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
