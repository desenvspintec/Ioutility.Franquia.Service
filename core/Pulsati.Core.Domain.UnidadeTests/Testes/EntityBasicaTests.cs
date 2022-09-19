using Cn.Core.Domain.Tests.Models;
using Pulsati.Core.Domain.DomainNotifications;
using Pulsati.Core.Domain.Services.Validacao;
using System;
using Xunit;

namespace Cn.Core.Domain.Tests.Testes
{
    public class EntityBasicaTests
    {
        private readonly EntityValidacaoService<EntityBasicaTeste> _entityValidacaoService = new(new DomainNotification());
        [Fact(DisplayName = "1 - EntityBasica - Invalida")]
        [Trait("Categoria", "Core Domain 2 - EntityBasica")]
        public void EhValido_EstaInvalido_ObterErroDeNomeEId()
        {
            // Arrange
            const int NUMERO_DE_ERROS_ESPERADOS = 4;
            var entity = new EntityBasicaTeste(Guid.Empty, "");
            // Act
            var ehValido = _entityValidacaoService.ValidarAsync(entity).Result;
            // Assert
            Assert.Equal(NUMERO_DE_ERROS_ESPERADOS, ehValido.ObterErros().Count);
            Assert.False(ehValido.EstaValido);
        }

        [Fact(DisplayName = "2 - EntityBasica - Nome com Iniciais em maiusculo")]
        [Trait("Categoria", "Core Domain 2 - EntityBasica")]
        public void AoConstruir_SetarNome_DeveTerIniciaisMausculas()
        {
            // Arrange
            var entity = new EntityBasicaTeste(Guid.NewGuid(), "  CASSIANO   A. DOS  ANJOS W NUNES");
            const string NOME_ESPERADO = "Cassiano A. dos Anjos W Nunes";

            // Act
            // o act acontece no construtor

            // Assert
            Assert.Equal(NOME_ESPERADO, entity.Nome);
        }

        //[Fact(DisplayName = "3 - EntityBasica - Nome para VALIDAÇÃO com preposição")]
        //[Trait("Categoria", "Core Domain 2 - EntityBasica")]
        //public void AoConstruir_SetarNome_DeveSetarTambemONomeParaValidacaoComPreposicao()
        //{
        //    // Arrange
        //    var entity = new EntityBasicaTesteNaoFiltraPreposicao(Guid.NewGuid(), "  CASSIANO ÉZIO AÇIS da de das do dos em no na w nunes ");
        //    const string NOME_ESPERADO = "cassiano ezio acis da de das do dos em no na w nunes";

        //    // Act
        //    // o act acontece no construtor

        //    // Assert
        //    Assert.Equal(NOME_ESPERADO, entity.NomeSemPreposicaoQuery);
        //}

        [Fact(DisplayName = "4 - EntityBasica - Nome para VALIDAÇÃO REMOVENDO preposição")]
        [Trait("Categoria", "Core Domain 2 - EntityBasica")]
        public void AoConstruir_SetarNome_DeveSetarTambemONomeParaValidacaoRemovendoPreposicao()
        {
            // Arrange
            var entity = new EntityBasicaTeste(Guid.NewGuid(), "  CASSIANO ÉZIO AÇIS da de das do dos em no na w nunes ");
            const string NOME_ESPERADO = "cassiano ezio acis w nunes";

            // Act
            // o act acontece no construtor

            // Assert
            Assert.Equal(NOME_ESPERADO, entity.NomeSemPreposicaoQuery);
        }

        [Fact(DisplayName = "5 - EntityBasica - Nome para Query filtrado para busca sem acentos e diferenciando maiusculas e minusculas")]
        [Trait("Categoria", "Core Domain 2 - EntityBasica")]
        public void AoConstruir_SetarNome_DeveSetarTambemONomeParaQueryFiltradoParaBusca()
        {
            // Arrange
            var entity = new EntityBasicaTesteNaoFiltraPreposicao(Guid.NewGuid(), "  CASSIANO ÉZIO AÇIS   da de das do dos em no na w nunes ");
            const string NOME_ESPERADO = "cassiano ezio acis da de das do dos em no na w nunes";

            // Act
            // o act acontece no construtor

            // Assert
            Assert.Equal(NOME_ESPERADO, entity.NomeQuery);
        }
    }
}
