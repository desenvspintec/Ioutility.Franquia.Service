using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Ioutility.Franquias.Domain.Franquias.Models;
using Microsoft.EntityFrameworkCore;
using Pulsati.Core.Repository.Repositorys;

namespace Ioutility.Franquias.Repository.Franquias.Repositorys
{
    public class FranquiaRepository : EntityBasicRepository<Franquia>, IFranquiaRepository
    {
        public FranquiaRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
