using Ioutility.Franquias.Domain.Procedimentos.Enums;
using Ioutility.Franquias.Domain.Procedimentos.Validacoes;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Models;

namespace Ioutility.Franquias.Domain.Procedimentos.Models
{
    public class Procedimento : Entity<Procedimento>
    {
        //EF CORE
        protected Procedimento()
        {

        }
        public Procedimento(Guid id,EEspecialidade especialidade, Guid tipoProcedimentoId, ProcedimentoValorVO valor, ProcedimentoComissaoVO comissao): base (id)
        {
            Especialidade = especialidade;
            TipoProcedimentoId = tipoProcedimentoId;
            Valor = valor;
            Comissao = comissao;
            Status = EProcedimentoStatus.Ativo;
            GerarCodigoVirtual();
        }

        public EEspecialidade Especialidade { get; private set; }
        public Guid TipoProcedimentoId { get; private set; }
        public ProcedimentoValorVO Valor { get; private set; }
        public ProcedimentoComissaoVO Comissao { get; private set; }
        
        public TipoProcedimento TipoProcedimento { get; private set; }
        public EProcedimentoStatus Status { get; private set; }
        public string CodigoVirtual { get; private set; }
        public override string DisplayNameTypeOf() => "Procedimento";

        protected override void SetValidacoes()
        {
            AddValidacao(new ProcedimentoValidacaoCommand(this));
            base.SetValidacoes();
        }

        private void GerarCodigoVirtual()
        {
            CodigoVirtual = Id.ToString().Split('-')[0] + DataCriacao.ToString("dd.MM.HH.ss");
            CodigoVirtual = CodigoVirtual.FormatarParaBusca();
        }
    }
}
