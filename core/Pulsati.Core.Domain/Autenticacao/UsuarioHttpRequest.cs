using Microsoft.AspNetCore.Http;
using Pulsati.Core.Domain.Autenticacao.Claims;
using System.Security.Claims;

namespace Pulsati.Core.Domain.Autenticacao
{
    public abstract class UsuarioHttpRequest
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IReadOnlyCollection<ClaimApp> _claimsApp;
        public UsuarioHttpRequest(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _claimsApp = GetClaimsDaAplicacaoParaConstrutor().ToList();
        }
        /// <summary>
        /// Adicionar as policys da aplicação
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<ClaimApp> GetClaimsDaAplicacaoParaConstrutor();
        public bool EstaLogado() => _accessor == null ? false : _accessor.HttpContext.User.Identity.IsAuthenticated;
        public IEnumerable<Claim> ClaimsPresentesNaRequisicao() => _accessor.HttpContext.User.Claims;
        public Guid Id() => !EstaLogado() ? Guid.Empty : new Guid(ClaimsPresentesNaRequisicao().First(claim => claim.Type.Contains("nameidentifier")).Value);
        public bool PossuiClaim(ClaimApp model) => ClaimsPresentesNaRequisicao().Any(claim => $"{claim.Type}.{claim.Value}" == model.Nome);

        public IEnumerable<ClaimApp> ClaimsFornecidasPelaApp() => _claimsApp;

    }
}
