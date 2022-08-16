using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Repositorys;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Models;

namespace Pulsati.Core.Domain.Services.Validacao.Command
{
    public class ValidarNaoDuplicidadeCommand<TEntity> : IValidacaoCommand<TEntity> where TEntity : IEntityBasic
    {
        private readonly IEntityQueryRepository<TEntity> _queryRepository;
        public ValidarNaoDuplicidadeCommand(IEntityQueryRepository<TEntity> queryRepository)
        {
            _queryRepository = queryRepository;
        }
        public async Task<ResultadoValidacao> ValidarAsync(TEntity entity)
        {
            var entityComMesmoNome = (await _queryRepository.BuscarOtimizadoPorPalavraChaveAsync(entity.NomeQuery)).FirstOrDefault();
            var existeEntityComMemsoNome = entityComMesmoNome != null && entityComMesmoNome.Id != entity.Id ;

            if (existeEntityComMemsoNome) return ResultadoValidacao.ObterComErro(MensagemErroHelper.EntityRepetida(entity.Nome));

            return ResultadoValidacao.ObterValido();
        }
    }
}
