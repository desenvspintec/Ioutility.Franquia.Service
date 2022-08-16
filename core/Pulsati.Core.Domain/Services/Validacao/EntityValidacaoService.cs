using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Models;

namespace Pulsati.Core.Domain.Services.Validacao
{
    public class EntityValidacaoService<TEntity> where TEntity : IEntityComDomainValidacao<TEntity>
    {
        private readonly List<IValidacaoCommand<TEntity>> _validacaoCommands = new();
        protected readonly DomainNotification DomainNotification;
        public EntityValidacaoService(DomainNotification domainNotification)
        {
            DomainNotification = domainNotification;
        }

        public void AddCommand(IValidacaoCommand<TEntity> validacaoCommand) => _validacaoCommands.Add(validacaoCommand);
        public void AddCommands(IEnumerable<IValidacaoCommand<TEntity>> validacaoCommand) => _validacaoCommands.AddRange(validacaoCommand);

        public async Task<ResultadoValidacao> ValidarAsync(TEntity entity, IEnumerable<IValidadorDomainCommand<TEntity>>? domainValidadores = null, IEnumerable<IValidacaoCommand<TEntity>>? complexosValidadores = null)
        {
            try
            {
                var resultadoValidacaoDomain = await _obterResultadoDeValidacaoDomain(entity, domainValidadores);
                if (!resultadoValidacaoDomain.EstaValido) return resultadoValidacaoDomain;

                if (complexosValidadores.EstaNulo())
                    complexosValidadores = _validacaoCommands.ToList();

                foreach (var command in complexosValidadores)
                {
                    var resultado = await _validarCommand(entity, command);
                    if (!resultado.EstaValido) return resultado;
                }



                return ResultadoValidacao.ObterValido();
            }
            catch (Exception erro)
            {

                throw new Exception("não foi possivel realizar a validação da entidade. mais detalhes na inner exception", erro);
            }
           
        }

        private async Task<ResultadoValidacao> _validarCommand(TEntity entity, IValidacaoCommand<TEntity> command)
        {
            var resultado = await command.ValidarAsync(entity);
            if (!resultado.EstaValido)
            {
                DomainNotification.AddRange(resultado.ObterErros().Select(erro => new Notification(Constante.ERRO_AO_VALIDAR_NA_ENTIDADE_DE_DOMINIO, erro)));
            }
            return resultado;
        }

        private async Task<ResultadoValidacao> _obterResultadoDeValidacaoDomain(TEntity entity, IEnumerable<IValidadorDomainCommand<TEntity>>? domainValidadores)
        {
            if (domainValidadores.EstaNulo())
                domainValidadores = entity.ObterDomainValidadorCommands();

            var resultadoValidacaoDomain = ResultadoValidacao.ObterValido();
            var domainErros = new List<string>();
            foreach (var command in domainValidadores)
            {
                var resultado = await command.ValidarAsync(entity);
                if (!resultado.EstaValido)
                    domainErros.AddRange(resultado.ObterErros());
            }

            DomainNotification.AddRange(domainErros.Select(erro => new Notification(Constante.ERRO_AO_VALIDAR_NA_ENTIDADE_DE_DOMINIO, erro)));
            resultadoValidacaoDomain.AddErros(DomainNotification.Obter().Select( domainNotification => domainNotification.Notificacao));
            return resultadoValidacaoDomain;
        }


    }

}
