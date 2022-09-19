using Pulsati.Core.Domain.DTOs;
using System;
using Xunit;

namespace Pulsati.Core.Domain.UnidadeTests.Testes.EntitysDTOs
{
    public class EntitysDTOTests
    {

        [Fact(DisplayName = "1 - EntityBasicDTO")]
        [Trait("Categoria", "Core Domain 7 - EntityDTO's")]
        public void Instanciar_DeveInicializarComSucesso_OsValoresDevemEstarCorreto()
        {
            // Arrange
            var entityId = Guid.NewGuid();
            var entityNome = "display";

            // Act
            var entity = new EntityBasicDTO(entityId, entityNome);

            // Assert
            Assert.Equal(entityId, entity.Id);
            Assert.Equal(entityNome, entity.Nome);
        }

        [Fact(DisplayName = "2 - EntityBasicDTO inicializar sem construtor")]
        [Trait("Categoria", "Core Domain 7 - EntityDTO's")]
        public void InstanciarSemConstrutor_DeveInicializarComSucesso_OsValoresDevemEstarCorreto()
        {
            // Arrange
            var entityId = Guid.NewGuid();
            var entityNome = "display";

            // Act
            var entity = new EntityBasicDTO { 
                Id = entityId,
                Nome = entityNome
            };

            // Assert
            Assert.Equal(entityId, entity.Id);
            Assert.Equal(entityNome, entity.Nome);
        }

        [Fact(DisplayName = "3 - EntityBasicDTOQuery")]
        [Trait("Categoria", "Core Domain 7 - EntityDTO's")]
        public void InstanciarSemConstrutorQuery_DeveInicializarComSucesso_OsValoresDevemEstarCorreto()
        {
            // Arrange
            var entityId = Guid.NewGuid();
            var entityNome = "display";

            // Act
            var entity = new EntityBasicDTOQuery()
            {
                Id = entityId,
                Nome = entityNome
            };

            // Assert
            Assert.Equal(entityId, entity.Id);
            Assert.Equal(entityNome, entity.Nome);
        }

        [Fact(DisplayName = "4 - EntityDTO")]
        [Trait("Categoria", "Core Domain 7 - EntityDTO's")]
        public void InstanciarEntityDTO_DeveInicializarComSucesso_OsValoresDevemEstarCorreto()
        {
            // Arrange
            var entityId = Guid.NewGuid();

            // Act
            var entity = new EntityDTO(entityId);

            // Assert
            Assert.Equal(entityId, entity.Id);
        }
        [Fact(DisplayName = "5 - EntityDTO sem construtor")]
        [Trait("Categoria", "Core Domain 7 - EntityDTO's")]
        public void InstanciarEntityDTOSemConstrutor_DeveInicializarComSucesso_OsValoresDevemEstarCorreto()
        {
            // Arrange
            var entityId = Guid.NewGuid();

            // Act
            var entity = new EntityDTO()
            {
                Id = entityId
            };

            // Assert
            Assert.Equal(entityId, entity.Id);
        }

        [Fact(DisplayName = "6 - EntityDTOQuery sem construtor")]
        [Trait("Categoria", "Core Domain 7 - EntityDTO's")]
        public void InstanciarEntityDTOQuerySemConstrutor_DeveInicializarComSucesso_OsValoresDevemEstarCorreto()
        {
            // Arrange
            var entityId = Guid.NewGuid();

            // Act
            var entity = new EntityDTOQuery()
            {
                Id = entityId
            };

            // Assert
            Assert.Equal(entityId, entity.Id);
        }
    }
}
