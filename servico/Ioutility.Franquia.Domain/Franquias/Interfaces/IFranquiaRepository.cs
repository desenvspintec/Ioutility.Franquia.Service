using Pulsati.Core.Domain.Interfaces.Repositorys;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Franquias.ViewModels;

namespace Ioutility.Franquias.Domain.Franquias.Interfaces
{
    public interface IFranquiaRepository : IEntityRepository<Franquia>
    {
        Task<IEnumerable<FranquiaListagemDTO>> BuscarAvancado(FranquiaBuscarAvancadoViewModel query);
    }
}
