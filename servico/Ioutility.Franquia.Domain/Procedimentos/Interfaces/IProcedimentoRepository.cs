using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Pulsati.Core.Domain.Interfaces.Repositorys;

namespace Ioutility.Franquias.Domain.Procedimentos.Interfaces
{
    public interface IProcedimentoRepository : IEntityRepository<Procedimento>
    {
        Task<IEnumerable<ProcedimentoListagemViewModel>> BuscarAvancado(ProcedimentoListagemQuery procedimentoListagemQuery);
    }
}
