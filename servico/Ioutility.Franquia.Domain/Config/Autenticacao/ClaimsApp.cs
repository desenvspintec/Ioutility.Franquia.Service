using Pulsati.Core.Domain.Autenticacao.Claims;

namespace Ioutility.Franquias.Domain.Config.Autenticacao
{
    public class ClaimsApp
    {
        public static IEnumerable<ClaimApp> ObterTodas()
        {
            return new List<ClaimApp>()
            {
                new ClaimApp(ClaimTipo.PACIENTE, ClaimValor.LER),
                new ClaimApp(ClaimTipo.PACIENTE, ClaimValor.ATUALIZAR),
                new ClaimApp(ClaimTipo.PACIENTE, ClaimValor.REGISTRAR),
                new ClaimApp(ClaimTipo.PACIENTE, ClaimValor.EXCLUIR)
            };
        }
    }
}
