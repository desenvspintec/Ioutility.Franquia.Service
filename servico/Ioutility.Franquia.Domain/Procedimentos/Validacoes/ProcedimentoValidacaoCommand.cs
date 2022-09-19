using Ioutility.Franquias.Domain.Procedimentos.Models;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Ioutility.Franquias.Domain.Procedimentos.Validacoes
{
    public class ProcedimentoValidacaoCommand : BaseEntityValidacaoCommand<Procedimento>
    {
        public ProcedimentoValidacaoCommand(Procedimento entity) : base(entity)
        {
        }

        public override void PreencherRegrasValidacao()
        {
            ValidarEntityDependente(procedimento => procedimento.Valor, "Valores do Procedimento");
            ValidarEntityDependente(procedimento => procedimento.Comissao, "Comissão do Procedimento");
        }
    }
}
