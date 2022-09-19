using Pulsati.Core.Domain.DisplayNames;
using Xunit;

namespace Pulsati.Core.Domain.UnidadeTests.Testes.DisplayNames
{
    public class DisplayNameTests
    {
        [Fact(DisplayName = "1 - Instanciar DisplayName")]
        [Trait("Categoria", "Core Domain 6 - DisplayName")]
        public void Instanciar_DeveInicializarComSucesso_OsValoresDevemEstarCorreto()
        {
            // Arrange
            var nomePropriedade = "properiedade";
            var valorDisplay = "display";

            // Act
            var displayName = new DisplayName(nomePropriedade, valorDisplay);

            // Assert
            Assert.Equal(nomePropriedade, displayName.NomePropriedade);
            Assert.Equal(valorDisplay, displayName.ValorDisplay);
        }
    }
}
