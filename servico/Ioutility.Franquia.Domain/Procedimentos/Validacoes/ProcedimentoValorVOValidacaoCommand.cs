using FluentValidation;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Ioutility.Franquias.Domain.Procedimentos.Validacoes
{
    public class ProcedimentoValorVOValidacaoCommand : BaseObjectValidacaoCommand<ProcedimentoValorVO>
    {
        public ProcedimentoValorVOValidacaoCommand(ProcedimentoValorVO entity) : base(entity)
        {
        }

        public override void PreencherRegrasValidacao()
        {
            const int VALOR_MAXIMO = 99999;
            const string PREFIXO_NOME_PROPRIEDADES = "Valor ";
            var propriedades = new
            {
                Sugerido = PREFIXO_NOME_PROPRIEDADES + "Sugerido",
                Minimo = PREFIXO_NOME_PROPRIEDADES + "Mínimo",
                Maximo = PREFIXO_NOME_PROPRIEDADES + "Máximo",
                CustoAdicional = "Custos Adicionais",
            };
            ValidarIntervaloNumerico(procedimentoValor => procedimentoValor.Sugerido, _entity.Maximo, _entity.Minimo, propriedades.Sugerido);
            ValidarIntervaloNumerico(procedimentoValor => procedimentoValor.Minimo, VALOR_MAXIMO, 0, propriedades.Minimo);
            ValidarIntervaloNumerico(procedimentoValor => procedimentoValor.Maximo, VALOR_MAXIMO, _entity.Minimo, propriedades.Maximo);
            ValidarIntervaloNumerico(procedimentoValor => procedimentoValor.CustoAdicional, VALOR_MAXIMO, 0, propriedades.CustoAdicional);

        }
    }
}
