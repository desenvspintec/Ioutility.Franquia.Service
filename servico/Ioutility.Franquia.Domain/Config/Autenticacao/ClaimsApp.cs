using Pulsati.Core.Domain.Autenticacao.Claims;

namespace Ioutility.Franquias.Domain.Config.Autenticacao
{
    public class ClaimsApp
    {
        public static IEnumerable<ClaimApp> ObterTodas()
        {
            return new List<ClaimApp>()
            {
                new ClaimApp(ClaimTipo.DENTISTA, ClaimValor.LER),
                new ClaimApp(ClaimTipo.DENTISTA, ClaimValor.ATUALIZAR),
                new ClaimApp(ClaimTipo.DENTISTA, ClaimValor.REGISTRAR),
                new ClaimApp(ClaimTipo.DENTISTA, ClaimValor.EXCLUIR)
            };
        }
    }
}
