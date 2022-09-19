using Cn.Core.Domain.Tests.Helpers;
using Cn.Core.Domain.Tests.Models;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Services.Validacao;
using System;
using System.Linq;
using Xunit;

namespace Cn.Core.Domain.Tests.Testes
{
    public class DomainNotificationTests
    {
        [Fact(DisplayName = "1 - Adicionar uma Notificação")]
        [Trait("Categoria", "Core Domain 3 - Domain Notification ")]
        public void Add_DeveAdicionar_ObterANotificacaoAdicionada()
        {
            // Arrange
            var domainNotifications = new DomainNotification();
            var notification = new Notification("este é um tipo", "esta é uma notificação");
            // Act
            domainNotifications.Add(notification.Tipo, notification.Notificacao);
            var notificacaoAdicionada = domainNotifications.Obter()
                                        .FirstOrDefault(ObterNotificacaoFunc(notification));
            // Assert
            Assert.NotNull(notificacaoAdicionada);
            Assert.True(domainNotifications.HaNotificacao());
        }
        private Func<Notification, bool> ObterNotificacaoFunc(Notification notification)
        {
            return domainNotification => domainNotification.Tipo == notification.Tipo && domainNotification.Notificacao == notification.Notificacao;
        }
        [Fact(DisplayName = "2 - Adicionar Notificações a partir de um validation result (AddRange)")]
        [Trait("Categoria", "Core Domain 3 - Domain Notification ")]
        public void AddRange_DeveAdicionarUmaLista_ObterAsNotificacoesAdicionada()
        {
            // Arrange
            var domainNotifications = new DomainNotification();
            var entityInvalida = new EntityTesteHelper().ObterEntityTotalmenteInvalidaComDependentesObrigatoriosNulos();

            // Act
            var entityInvalidaResult = new EntityValidacaoService<EntityTeste>(domainNotifications).ValidarAsync(entityInvalida).Result;
            
            // Assert
            Assert.Equal(entityInvalidaResult.ObterErros(false).Count, domainNotifications.Obter().Count);
        }

        [Fact(DisplayName = "3 - Notification deve estar com descrição correta")]
        [Trait("Categoria", "Core Domain 3 - Domain Notification ")]
        public void InstanciarNotification_DevePreencherConstrutor_DevePossuirDescricaoCorreta()
        {
            // Arrange
            var tipo = "t";
            var notificacao = "a";
            var descricao = $"{tipo} - {notificacao}";
            // Act
            var notification= new Notification(tipo, notificacao);

            // Assert
            Assert.Equal(descricao, notification.ObterDescricao());
        }


    }
}
