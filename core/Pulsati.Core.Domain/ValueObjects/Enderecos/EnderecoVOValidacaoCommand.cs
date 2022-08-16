using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Pulsati.Core.Domain.ValueObjects.Enderecos
{
    public class EnderecoVOValidacaoCommand : BaseObjectValidacaoCommand<EnderecoVO>
    {
        public EnderecoVOValidacaoCommand(EnderecoVO entity) : base(entity)
        {
        }

        public override void PreencherRegrasValidacao()
        {
            ValidarCampoTextoBasico(end => end.Cep, "CEP", true, EnderecoConstante.LENGTH_CEP, EnderecoConstante.LENGTH_CEP);
            ValidarCampoTextoBasico(end => end.Logradouro, "Logradouro", true, EnderecoConstante.MAX_LENGTH_ENDERECO);
            ValidarCampoTextoBasico(end => end.Bairro, "", true);
            ValidarCampoTextoBasico(end => end.Estado, "", true);
            ValidarCampoTextoBasico(end => end.Uf, "", true);
            ValidarIntervaloNumerico(end => end.Numero, EnderecoConstante.NUMERO_RESIDENCIA_MAXIMO, 1, "Número");
            ValidarCampoTamanhoMaximo(end => end.Complemento);
        }
    }
}
