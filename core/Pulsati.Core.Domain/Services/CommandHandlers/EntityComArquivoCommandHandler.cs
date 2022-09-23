using AutoMapper;
using Pulsati.Core.Domain.Bus.MessagesDTO.Storage;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.EventSources;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.DTOs;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Services.TransferirArquivos;
using Pulsati.Core.Domain.Services.Validacao;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Pulsati.Core.Domain.Services.CommandHandlers
{
    public class EntityComArquivoCommandHandler<TEntity, TRegistrarCommand, TAtualizarCommand> : EntityCommandHandler<TEntity, TRegistrarCommand, TAtualizarCommand>
        where TEntity : class, IEntityComDomainValidacao<TEntity>, IEntityComArquivo
        where TRegistrarCommand : class, IEntityDTO
        where TAtualizarCommand : class, IEntityDTO
    {
        public EntityComArquivoCommandHandler(DomainNotification domainNotification, IEntityRepository<TEntity> repository, IMapper mapper, EntityValidacaoService<TEntity> validadorService, EventStoreService eventStoreService) : base(domainNotification, repository, mapper, validadorService, eventStoreService)
        {
            HabilitarManipulacaoArquivo();
        }
        protected static async Task SalvarArquivosAoConfirmarFormularioAsync(IEntityComArquivo entity)
        {
            var origemDosArquivos = ArquivoHelper.NOME_PASTA_TEMPORARIA;
            var moverArquivosDTO = new List<MoverArquivoCommand>();

            foreach (var arquivo in entity.ObterTodosArquivosComDiretorio())
            {
                moverArquivosDTO.Add(new MoverArquivoCommand()
                {
                    IgnorarErros = false,
                    CaminhoAtual = origemDosArquivos + arquivo.Nome,
                    CaminhoMover = arquivo.DiretorioVirtualCompleto,
                    Copiar = false,
                    Substituir = true
                });
            }

            using var storageService = new StorageService();
            await storageService.MoverArquivoRange(moverArquivosDTO);
        }
        protected static async Task MoverArquivosParaLixeiraAsync(IEntityComArquivo entity)
        {
            var lixeira = ArquivoHelper.NOME_PASTA_LIXEIRA;
            var moverArquivosDTO = new List<MoverArquivoCommand>();

            foreach (var arquivo in entity.ObterTodosArquivosComDiretorio())
            {
                moverArquivosDTO.Add(new MoverArquivoCommand()
                {
                    IgnorarErros = false,
                    CaminhoMover = lixeira + arquivo.Nome,
                    CaminhoAtual = arquivo.DiretorioVirtualCompleto,
                    Copiar = false,
                    Substituir = true
                });
            }

            using var storageService = new StorageService();
            await storageService.MoverArquivoRange(moverArquivosDTO);
        }
        
        protected void HabilitarManipulacaoArquivo()
        {
            ValidadorService.AddCommand(new ValidarExistenciaDeArquivoCommand<TEntity>());
            static async Task salvarArquivoAoRegistrarDelegate(TEntity entity, TRegistrarCommand dto) => await SalvarArquivosAoConfirmarFormularioAsync(entity);
            static async Task salvarArquivoAoAtualizarDelegate(TEntity entity, TAtualizarCommand dto) => await SalvarArquivosAoConfirmarFormularioAsync(entity);
            static async Task deletarArquivosDelegate(TEntity entity, EntityInativarCommand dto) => await MoverArquivosParaLixeiraAsync(entity);

            SetDelegatesDeOperacaoAposFinalizarMetodo(salvarArquivoAoRegistrarDelegate, salvarArquivoAoAtualizarDelegate, deletarArquivosDelegate);
        }
    }
}
