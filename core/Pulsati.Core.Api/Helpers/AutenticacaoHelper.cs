using Pulsati.Core.Domain.Autenticacao;
using Pulsati.Core.Domain.Autenticacao.Claims;
using Pulsati.Core.Domain.Helpers;

namespace Pulsati.Core.Api.Helpers
{
    public class AutenticacaoApiHelper
    {
        private readonly IReadOnlyCollection<ClaimApp> _claimsDaController;

        public AutenticacaoApiHelper()
        {
            ExigeAutenticacao = false;
        }
        public AutenticacaoApiHelper(string tipoClaimUtilizar, UsuarioHttpRequest usuarioHttpRequest)
        {
            ExigeAutenticacao = true;
            TipoClaimUtilizar = tipoClaimUtilizar;
            _claimsDaController = usuarioHttpRequest.ClaimsFornecidasPelaApp().Where(policyUsuarioApp => policyUsuarioApp.ClaimTipo == TipoClaimUtilizar).ToList();
            UsuarioHttpRequest = usuarioHttpRequest;
        }
        public UsuarioHttpRequest UsuarioHttpRequest { get; private set; }
        public bool ExigeAutenticacao { get; private set; }
        public string TipoClaimUtilizar { get; private set; }
        private ClaimApp _obterClaimDaControlerPorValor(string claimValor)
        {
            var policy = _claimsDaController.Where(claimController => claimController.ClaimValor == claimValor).FirstOrDefault();
            if (policy == null)
            {
                ExceptionHelper.LancarErroException($"O acesso necessitou uma policy inexistente na aplicação. Nome da claim: {TipoClaimUtilizar}.{claimValor}");
                throw new Exception();
            }
            return policy;
        }

        public bool EstaAutorizado(ClaimApp claimApp) => !ExigeAutenticacao || UsuarioHttpRequest.PossuiClaim(claimApp);
        public bool EstaAutorizado(string claimValor) => !ExigeAutenticacao || UsuarioHttpRequest.PossuiClaim(_obterClaimDaControlerPorValor(claimValor));

        public bool EstaAutorizadoLer() => EstaAutorizado(ClaimValor.LER);
        public bool EstaAutorizadoRegistrar() => EstaAutorizado(ClaimValor.REGISTRAR);
        public bool EstaAutorizadoAtualizar() => EstaAutorizado(ClaimValor.ATUALIZAR);
        public bool EstaAutorizadoExcluir() => EstaAutorizado(ClaimValor.EXCLUIR);


    }
}
