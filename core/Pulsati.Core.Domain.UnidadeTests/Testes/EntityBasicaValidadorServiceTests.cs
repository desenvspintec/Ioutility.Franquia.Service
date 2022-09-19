//using Cn.Core.Domain.Interfaces;
//using Cn.Core.Domain.Notifications;
//using Cn.Core.Domain.Services.Validador;
//using Cn.Core.Domain.Tests.Models;
//using Moq;
//using Moq.AutoMock;
//using Pulsati.Core.Domain.DomainNotifications;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;
//namespace Cn.Core.Domain.Tests.Testes
//{
//    public class EntityBasicaValidadorServiceTests
//    {
//        private readonly IValidadorService<EntityBasicaTeste> _validadorService;
//        private readonly DomainNotification _domainNotification;
//        private readonly Mock<IEntityBasicaRepository<EntityBasicaTeste>> _repositoryMocker;
//        private const string NOME_ENTITY_NA_LISTA = "Cassiano Campos";
//        public EntityBasicaValidadorServiceTests()
//        {
//            _repositoryMocker = new Mock<IEntityBasicaRepository<EntityBasicaTeste>>();
//            _domainNotification = new DomainNotification();
//            _validadorService = new EntityBasicaValidadorService<EntityBasicaTeste>(_domainNotification, _repositoryMocker.Object);
//        }

//        [Fact(DisplayName = "1 - Deve notificar validação de dominio")]
//        [Trait("Categoria", "Core Domain 5 - Validação Service")]
//        public void EhValido_NaoEstaValido_DeveNotificarValidacaoNoDominio()
//        {
//            // Arrange
//            var entity = new EntityBasicaTeste(Guid.NewGuid(), "");

//            // Act
//            var ehValido = _validadorService.EhValidoAsync(entity).Result;

//            // Assert
//            Assert.Single(_domainNotification.Obter());
//            Assert.False(ehValido);
//        }

//        [Fact(DisplayName = "2 - Deve notificar validação de entity repetida filtrando preposição do nome")]
//        [Trait("Categoria", "Core Domain 5 - Validação Service")]
//        public void EhValido_NaoEstaValido_DeveNotificarEntityRepetidaFiltrandoPreposicao()
//        {
//            // Arrange
//            var entity = new EntityBasicaTeste(Guid.NewGuid(), "Cassiano de Campos");
//            _repositoryMocker.Setup(repo => repo.BuscarPorNomeFiltrandoPreposicaoAsync(entity.NomeParaValidacao, null)).Returns(_obterEntityBasicaTestesComUmRegistro());

//            // Act
//            var ehValido = _validadorService.EhValidoAsync(entity).Result;

//            // Assert
//            Assert.Single(_domainNotification.Obter());
//            Assert.False(ehValido);
//        }

//        private Task<IList<EntityBasicaTeste>> _obterEntityBasicaTestesComUmRegistro()
//        {
//            var lista = new List<EntityBasicaTeste>() { 
//                new EntityBasicaTeste(Guid.NewGuid(), NOME_ENTITY_NA_LISTA)
//            };
//            return Task.Run<IList<EntityBasicaTeste>>(() => lista);
//        }

//        [Fact(DisplayName = "3 - Deve notificar validação de entity repetida NÃO filtrando preposição do nome")]
//        [Trait("Categoria", "Core Domain 5 - Validação Service")]
//        public void EhValido_NaoEstaValido_DeveNotificarEntityRepetidaNAOFiltrandoPreposicao()
//        {
//            // Arrange
//            var repositoryMocker = new Mock<IEntityBasicaRepository<EntityBasicaTesteNaoFiltraPreposicao>>();
//            var validadorService = new EntityBasicaValidadorService<EntityBasicaTesteNaoFiltraPreposicao>(_domainNotification, repositoryMocker.Object);
//            var entity = new EntityBasicaTesteNaoFiltraPreposicao(Guid.NewGuid(), "Cassiano Campos");

//            repositoryMocker.Setup(repo => repo.BuscarPorNomeAsync(entity.NomeParaValidacao, null)).Returns(_obterEntityBasicaTestesSemFiltroPreposicaoComUmRegistro());

//            // Act
//            var ehValido = validadorService.EhValidoAsync(entity).Result;

//            // Assert
//            Assert.Single(_domainNotification.Obter());
//            Assert.False(ehValido);
//        }
//        private Task<IList<EntityBasicaTesteNaoFiltraPreposicao>> _obterEntityBasicaTestesSemFiltroPreposicaoComUmRegistro()
//        {
//            var lista = new List<EntityBasicaTesteNaoFiltraPreposicao>() {
//                new EntityBasicaTesteNaoFiltraPreposicao(Guid.NewGuid(), NOME_ENTITY_NA_LISTA)
//            };
//            return Task.Run<IList<EntityBasicaTesteNaoFiltraPreposicao>>(() => lista);
//        }

//        [Fact(DisplayName = "4 - Deve estar valida mesmo com nome repetido")]
//        [Trait("Categoria", "Core Domain 5 - Validação Service")]
//        public void EhValido_EstaValido_NaoDeveHaverNotificacaoDeDuplicidade()
//        {
//            // Arrange
//            var repositoryMocker = new Mock<IEntityBasicaRepository<EntityBasicaTesteRepetivel>>();
//            var validadorService = new EntityBasicaValidadorService<EntityBasicaTesteRepetivel>(_domainNotification, repositoryMocker.Object);
//            var entity = new EntityBasicaTesteRepetivel(Guid.NewGuid(), NOME_ENTITY_NA_LISTA);

//            // Act
//            var ehValido = validadorService.EhValidoAsync(entity).Result;

//            // Assert
//            Assert.Empty(_domainNotification.Obter());
//            Assert.True(ehValido);
//        }
//        private Task<IList<EntityBasicaTesteRepetivel>> _obterEntityBasicaTestesRepetivel()
//        {
//            var lista = new List<EntityBasicaTesteRepetivel>() {
//                new EntityBasicaTesteRepetivel(Guid.NewGuid(), NOME_ENTITY_NA_LISTA)
//            };
//            return Task.Run<IList<EntityBasicaTesteRepetivel>>(() => lista);
//        }
//    }
//}
