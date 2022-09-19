using Ioutility.Franquias.Domain.Franquias.DTOs.Gerais;
using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Newtonsoft.Json;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Helpers;

namespace Ioutility.Franquias.Repository.JsonRepositorys.Bancos
{
    public class BancoRepository : IBancoRepository
    {
        private IEnumerable<BancoDTO>? _bancoDTOs = null;

        private IEnumerable<BancoDTO> _buscarBancos()
        {
            if (_bancoDTOs == null)
                _bancoDTOs = JsonConvert.DeserializeObject<IEnumerable<BancoDTO>>(_obterBancosJson());
            return _bancoDTOs!;
        }

        private string _obterBancosJson()
        {
            return ArquivoHelper.LerArquivoDoDiretorioPadraoJson("BancosDb.json");
        }

        public BancoDTO? BuscarPorId(string id)
        {
            return _buscarBancos().FirstOrDefault(banco => banco.Value == id);
        }

        public IEnumerable<BancoDTO> BuscarTodos(string nome)
        {
            return _buscarBancos().Where(banco =>
                banco.LabelValue.FormatarParaBusca().Contains(nome.FormatarParaBusca()));

        }
    }
}
