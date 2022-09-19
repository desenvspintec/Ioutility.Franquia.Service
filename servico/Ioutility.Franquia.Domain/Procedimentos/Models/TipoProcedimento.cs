using Pulsati.Core.Domain.Models;

namespace Ioutility.Franquias.Domain.Procedimentos.Models
{
    public class TipoProcedimento : EntityBasic<TipoProcedimento>
    {
        public TipoProcedimento(Guid id, string nome) : base(id, nome)
        {
        }
        // EF CORE
        protected TipoProcedimento()
        {
        }

        public override string DisplayNameTypeOf() => "Tipo de Procedimento";

        public IEnumerable<Procedimento> Procedimentos { get; private set; }
    }
}