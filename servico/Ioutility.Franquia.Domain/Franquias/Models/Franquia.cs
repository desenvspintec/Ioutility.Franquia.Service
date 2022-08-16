using Pulsati.Core.Domain.Models;
using Pulsati.Core.Domain.ValueObjects.Enderecos;

namespace Ioutility.Franquias.Domain.Franquias.Models
{
    public class Franquia : EntityBasic<Franquia>
    {
        // EF CORE
        protected Franquia()
        {

        }
        public Franquia(Guid id, string nome, EnderecoVO endereco, FranquiaDadoBancario dadoBancario) : base(id, nome)
        {
            Endereco = endereco;
            DadoBancario = dadoBancario;
        }
        public EnderecoVO Endereco { get; private set; }
        public FranquiaDadoBancario DadoBancario { get; private set; }

        public override string DisplayNameTypeOf()
        {
            return "Franquia";
        }
    }
}
