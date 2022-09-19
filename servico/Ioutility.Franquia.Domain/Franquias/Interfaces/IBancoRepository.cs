using Ioutility.Franquias.Domain.Franquias.DTOs.Gerais;

namespace Ioutility.Franquias.Domain.Franquias.Interfaces
{
    public interface IBancoRepository
    {
        public IEnumerable<BancoDTO> BuscarTodos(string nome);
        public BancoDTO? BuscarPorId(string id);
    }
}
