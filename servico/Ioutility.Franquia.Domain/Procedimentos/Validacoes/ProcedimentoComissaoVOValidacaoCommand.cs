using Ioutility.Franquias.Domain.Procedimentos.Models;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Ioutility.Franquias.Domain.Procedimentos.Validacoes
{
    public class ProcedimentoComissaoVOValidacaoCommand : BaseObjectValidacaoCommand<ProcedimentoComissaoVO>
    {
        public ProcedimentoComissaoVOValidacaoCommand(ProcedimentoComissaoVO entity) : base(entity)
        {
        }

        public override void PreencherRegrasValidacao()
        {
            const string PROPRIEDADE = "Valor da Comissão";
            switch (_entity.Tipo)
            {
                case ETipoComissao.Fixo:
                    ValidarComissaoFixa(PROPRIEDADE);
                    break;
                case ETipoComissao.Variavel:
                    ValidarComissaoVariavel(PROPRIEDADE);
                    break;
                default:
                    ExceptionHelper.LancarErroException($"Não foi possivel validar o tipo de comissão, valor {_entity.Tipo} não suportado");
                    break;
            }

        }

        private void ValidarComissaoVariavel(string PROPRIEDADE)
        {
            var maximo = 1000.0;
            ValidarIntervaloNumerico(comissao => comissao.Valor, maximo, 0, PROPRIEDADE);
        }

        private void ValidarComissaoFixa(string PROPRIEDADE)
        {
            var maximo = 99999.0;
            ValidarIntervaloNumerico(comissao => comissao.Valor, maximo, 0, PROPRIEDADE);
        }
    }
}
