using Ioutility.Franquias.Domain.Config.Autenticacao;
using Pulsati.Core.Domain.Autenticacao;
using Pulsati.Core.Domain.Autenticacao.Claims;

namespace Ioutility.Franquias.Api.Config.Autenticacao
{
    public class FranquiaUsuarioHttpResquest : UsuarioHttpRequest
    {
        public FranquiaUsuarioHttpResquest(IHttpContextAccessor accessor) : base(accessor)
        {
        }

        protected override IEnumerable<ClaimApp> GetClaimsDaAplicacaoParaConstrutor()
        {
            return ClaimsApp.ObterTodas();
        }
    }
}
