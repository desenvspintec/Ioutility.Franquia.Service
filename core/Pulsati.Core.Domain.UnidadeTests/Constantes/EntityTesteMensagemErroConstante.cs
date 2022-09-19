using Cn.Core.Domain.Tests.Models;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.Helpers;

namespace Pulsati.Core.Domain.UnidadeTests.Constantes
{
    public class EntityTesteMensagemErroConstante
    {
        public static string ID = MensagemErroHelper.NaoNulo(nameof(EntityTeste.Id));
        public static string TEXTO_OBRIGATORIO = MensagemErroHelper.NaoNulo("Texto Obrigatorio");
        public static string TEXTO_MINIMO = MensagemErroHelper.MinLength(nameof(EntityTeste.TextoMinimo), Constante.MIN_LEN_PADRAO);
        public static string TEXTO_MAXIMO = MensagemErroHelper.MaxLength(nameof(EntityTeste.TextoMaximo), Constante.MAX_LEN_PADRAO);
        public static string DATA = MensagemErroHelper.DataMaiorQue(nameof(EntityTeste.Data), Constante.DATA_MINIMA_PARA_SER_CORENTE);
        public static string DATA_MINIMA_ATUAL = MensagemErroHelper.DataMaiorQue("Data Atual", Constante.DATA_ATUAL);
        public static string EMAIL = MensagemErroHelper.EmailNaoValido(nameof(EntityTeste.Email));
        public static string LISTA_DEPENDENTE_OBRIGATORIA = MensagemErroHelper.NaoNulo(nameof(EntityTeste.DependentesObrigatorios));
        public static string LISTA_DEPENDENTE_NAO_REPETIDA = MensagemErroHelper.ListaRepetida("Dependentes não repetidos");
        public static string LISTA_DEPENDENTE_INVALIDO = MensagemErroHelper.NaoNulo("Id Dependente");
    }
}
