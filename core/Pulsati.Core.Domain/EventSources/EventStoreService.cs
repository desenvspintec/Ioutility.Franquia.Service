using Pulsati.Core.Domain.Enums;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Interfaces;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Repositorys;

namespace Pulsati.Core.Domain.EventSources
{
    public class EventStoreService
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public EventStoreService(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task SalvarEventAsync<TEntity>(TEntity entity, ETipoOperacaoCrud tipoOperacaoCrud, object dados) where TEntity : IDisplayNameTypeOf, IMessage
        {
            var jsonDados = _obterDadosEmJson(dados);
            var eventStore = new EventSource(Guid.NewGuid(), entity.Id, Helper.ObterNomeClasse<TEntity>(), entity.DisplayNameTypeOf(), jsonDados, tipoOperacaoCrud);

            await _eventStoreRepository.AddEvent(eventStore);
        }

        private static string _obterDadosEmJson(object dados)
        {
            string jsonDados;
            try
            {
                jsonDados = Newtonsoft.Json.JsonConvert.SerializeObject(dados);
            }
            catch (Exception exception)
            {
                var mensagemErro = "Não foi possivel gerar LOG, pois não foi possivel converter os dados para json. erro: " + exception.Message;
                ExceptionHelper.LancarErroException(mensagemErro);
                throw;
            }

            return jsonDados;
        }
    }
}
