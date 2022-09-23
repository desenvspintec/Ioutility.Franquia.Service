using AutoMapper;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.EventSources;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Services.CommandHandlers;
using Pulsati.Core.Domain.Services.Validacao;
using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Franquias.Interfaces;

namespace Ioutility.Franquias.Domain.Franquias.Services
{
    public class FranquiaCommandHandler : EntityComArquivoCommandHandler<Franquia, FranquiaDTO, FranquiaDTO>
    {
        public FranquiaCommandHandler(DomainNotification domainNotification, IFranquiaRepository repository, IMapper mapper, EntityValidacaoService<Franquia> validadorService, EventStoreService eventStoreService) : base(domainNotification, repository, mapper, validadorService, eventStoreService)
        {
            _configurarPreenchimentoDependecia();
        }
        private void _configurarPreenchimentoDependecia()
        {
            static void definirStatusAtivoAntesDoMap(FranquiaDTO franquiaDTO)
            {
                FranquiaAcessoVODTO novoFranquiaDTO = new FranquiaAcessoVODTO();

                novoFranquiaDTO.FranquiaStatus = Enums.EFranquiaStatus.Ativo;

                franquiaDTO.Acesso = novoFranquiaDTO;

            }
            SetDelegatesDeEntityDependente(definirStatusAtivoAntesDoMap, null, null);
        }
       
        public async Task HandlerAtualizarStatusAsync(FranquiaAtualizarStatusCommand command)
        {
            if (command == null)
            {
                ExceptionHelper.LancarErroException("o comando nao pode ser nulo");
                throw new Exception();
            }
            var entity = await Repository.BuscarPorIdAsync(command.Id);
            entity.SetStatus(command.FranquiaStatus);
            Repository.Atualizar(entity);

            await CommandHandlerHelper.GerarLogAsync(entity, command, ETipoOperacaoCrud.Atualizar);
            await Repository.CommitAsync();
        }
    }
}
