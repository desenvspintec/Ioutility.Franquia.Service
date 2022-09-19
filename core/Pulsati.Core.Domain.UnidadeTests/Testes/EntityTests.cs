using Cn.Core.Domain.Tests.Helpers;
using Cn.Core.Domain.Tests.Models;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Services.Validacao;
using Pulsati.Core.Domain.UnidadeTests.Constantes;
using Xunit;
namespace Cn.Core.Domain.Tests.Testes
{

    public class EntityTests
    {
        private readonly EntityTesteHelper _helper;
        private readonly EntityValidacaoService<EntityTeste> _validacaoService = new(new DomainNotification());

        public EntityTests()
        {
            _helper = new EntityTesteHelper();
        }
        [Fact(DisplayName = "Entity valida")]
        [Trait("Categoria", "Core Domain 1 - Entity")]
        public void EhValido_EstaValido_NaoDeveHaverErros()
        {
            // Arrange
            var entityComDependentesNaoRepetidosPreenchido = _helper.ObterEntityValidaComListaDeDependentesNaoRepetidosNulo();
            var entityComDependentesNaoRepetidosNulo = _helper.ObterEntityValidaComListaDeDependentesNaoRepetidosNulo();

            // Act
            var ehValidoDependentesNaoRepetidosPreenchido = _validacaoService.ValidarAsync(entityComDependentesNaoRepetidosPreenchido).Result;
            var ehValidoDependentesNaoRepetidosNulo = _validacaoService.ValidarAsync(entityComDependentesNaoRepetidosNulo).Result;

            // Assert
            Assert.Empty(ehValidoDependentesNaoRepetidosPreenchido.ObterErros());
            Assert.Empty(ehValidoDependentesNaoRepetidosNulo.ObterErros());
            
            Assert.True(ehValidoDependentesNaoRepetidosPreenchido.EstaValido);   
            Assert.True(ehValidoDependentesNaoRepetidosNulo.EstaValido);
        }
        [Fact(DisplayName = "Entity invalida - Todos os erros")]
        [Trait("Categoria", "Core Domain 1 - Entity")]
        public void EhValido_EstaInvalido_ObterTodosOsErros()
        {
            // Arrange
            var entityComEntityDependentesObrigatorioVazio = _helper.ObterEntityTotalmenteInvalidaComDependentesObrigatoriosVazio();
            var entityComEntityDependentesObrigatorioNulo = _helper.ObterEntityTotalmenteInvalidaComDependentesObrigatoriosNulos();

            // Act
            var ehValidoEntityComEntityDependentesObrigatorioVazio = _validacaoService.ValidarAsync(entityComEntityDependentesObrigatorioVazio).Result;
            var ehValidoEntityComEntityDependentesObrigatorioNulo = _validacaoService.ValidarAsync(entityComEntityDependentesObrigatorioNulo).Result;

            // Assert
            Assert.Equal(EntityTesteMensagemErroConstante.ID, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.ID));
            Assert.Equal(EntityTesteMensagemErroConstante.TEXTO_MINIMO, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.TEXTO_MINIMO));
            Assert.Equal(EntityTesteMensagemErroConstante.TEXTO_MAXIMO, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.TEXTO_MAXIMO));
            Assert.Equal(EntityTesteMensagemErroConstante.DATA, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.DATA));
            Assert.Equal(EntityTesteMensagemErroConstante.DATA_MINIMA_ATUAL, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.DATA_MINIMA_ATUAL));
            Assert.Equal(EntityTesteMensagemErroConstante.EMAIL, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.EMAIL));
            Assert.Equal(EntityTesteMensagemErroConstante.LISTA_DEPENDENTE_OBRIGATORIA, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.LISTA_DEPENDENTE_OBRIGATORIA));
            Assert.Equal(EntityTesteMensagemErroConstante.LISTA_DEPENDENTE_OBRIGATORIA, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.LISTA_DEPENDENTE_OBRIGATORIA));
            Assert.Equal(EntityTesteMensagemErroConstante.LISTA_DEPENDENTE_NAO_REPETIDA, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.LISTA_DEPENDENTE_NAO_REPETIDA));
            Assert.Equal(EntityTesteMensagemErroConstante.LISTA_DEPENDENTE_INVALIDO, _helper.ObterErroDeEntityInvalida(ehValidoEntityComEntityDependentesObrigatorioVazio, EntityTesteMensagemErroConstante.LISTA_DEPENDENTE_INVALIDO));
            
            Assert.Equal(EntityTesteHelper.NUMERO_MAXIMO_DE_ERROS, ehValidoEntityComEntityDependentesObrigatorioVazio.ObterErros().Count);
            Assert.Equal(EntityTesteHelper.NUMERO_MAXIMO_DE_ERROS + 1, ehValidoEntityComEntityDependentesObrigatorioNulo.ObterErros().Count);

            Assert.True(!ehValidoEntityComEntityDependentesObrigatorioVazio.EstaValido);
            Assert.True(!ehValidoEntityComEntityDependentesObrigatorioVazio.EstaValido);

        }

    }
}
