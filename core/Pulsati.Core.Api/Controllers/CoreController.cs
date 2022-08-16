using Microsoft.AspNetCore.Mvc;
using Pulsati.Core.Api.Enums;
using Pulsati.Core.Api.Helpers;
using Pulsati.Core.Api.ViewModels;
using Pulsati.Core.Domain.Autenticacao;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Services.TransferirArquivos;

namespace Pulsati.Core.Api.Controllers
{
    public abstract class CoreController : ControllerBase
    {
        protected readonly DomainNotification DomainNotification;
        protected readonly AutenticacaoApiHelper AutenticacaoApiHelper;
        public CoreController(DomainNotification domainNotification, UsuarioHttpRequest? usuarioHttpRequest, bool exigeAutenticacao = true)
        {
            DomainNotification = domainNotification;
            if (exigeAutenticacao && !usuarioHttpRequest.EstaNulo())
                AutenticacaoApiHelper = new AutenticacaoApiHelper(GetClaimTipoParaContrutor(), usuarioHttpRequest!);
            else
                AutenticacaoApiHelper = new AutenticacaoApiHelper();
        }
        #region autenticação
        protected abstract string GetClaimTipoParaContrutor();
        protected bool EstaAutorizadoLer() => AutenticacaoApiHelper.EstaAutorizadoLer();
        protected bool EstaAutorizadoRegistrar() => AutenticacaoApiHelper.EstaAutorizadoRegistrar();
        protected bool EstaAutorizadoAtualizar() => AutenticacaoApiHelper.EstaAutorizadoAtualizar();
        protected bool EstaAutorizadoExcluir() => AutenticacaoApiHelper.EstaAutorizadoExcluir();
        #endregion
        protected bool OperacaoValida() => !DomainNotification.Obter().Any();
        protected new IActionResult Response(object? result = null, ETipoRespostaSuccess tipoRespostaSuccess = ETipoRespostaSuccess.Ok)
        {
            if (OperacaoValida())
            {
                switch (tipoRespostaSuccess)
                {
                    case ETipoRespostaSuccess.Created:
                        return Created("", result);
                    case ETipoRespostaSuccess.NoContent:
                        return NoContent();
                    default:
                        return Ok(result);
                }
            }

            return BadRequest(new RespostaErroDeNotificacaoViewModel()
            {
                success = false,
                errorsDetails = DomainNotification.Obter(),
                errors = DomainNotification.Obter().Select(notificacao => notificacao.Notificacao)
            });
        }

        protected async Task DisponibilizarArquivosNaPastaTemporariaAsync(IEntityComArquivo entity)
        {
            using var storageService = new StorageService();
            await storageService.DisponibilizarArquivosNaPastaTemporaria(entity.ObterTodosArquivosComDiretorio());
        }

    }
}
