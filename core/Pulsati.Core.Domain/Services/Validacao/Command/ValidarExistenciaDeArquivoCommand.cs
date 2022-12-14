using Pulsati.Core.Domain.DTOs.Arquivos;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Models;
using Pulsati.Core.Domain.Services.TransferirArquivos;

namespace Pulsati.Core.Domain.Services.Validacao.Command
{
    public class ValidarExistenciaDeArquivoCommand<TEntity> : IValidacaoCommand<TEntity>
        where TEntity : IEntityComDomainValidacao<TEntity>, IEntityComArquivo
    {
        
        protected static async Task<ConsultarExistenciaArquivosResultadoDTO> ArquivosExistemNaPastaTemporaria(IEntityComArquivo entity)
        {
            var origemDosArquivos = ArquivoHelper.NOME_PASTA_TEMPORARIA;
            var diretorios = entity.ObterTodosArquivosComDiretorio().Select(arquivo => origemDosArquivos + arquivo.Nome);


            using var storageService = new StorageService();
            return await storageService.ArquivosExistem(diretorios);
        }

        public async Task<ResultadoValidacao> ValidarAsync(TEntity entity)
        {
            var resultado = await ArquivosExistemNaPastaTemporaria(entity);
            if (resultado.TodoArquivosExistem) return ResultadoValidacao.ObterValido();

            return ResultadoValidacao.ObterComErro(MensagemErroHelper.ArquivoNaoEncontradoNaPastaTemporaria(resultado));
        }
    }
}
