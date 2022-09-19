using Pulsati.Core.Domain.Autenticacao.Claims;
using Xunit;

namespace Pulsati.Core.Domain.UnidadeTests.Testes.Autenticacao
{
    public class ClaimAppTests
    {
        [Fact(DisplayName = "1 - Claims app")]
        [Trait("Categoria", "Core Domain 4 - Autenticação ")]
        public void AoInstanciar_DevePreencherDados_DevemEstarCorretos()
        {
            // Arrange
            var claimTipo = "a.1";
            var claimValor = "b.2";
            var claimNome = $"{claimTipo}.{claimValor}";
            var resumo = $"{claimTipo.Split('.')[1]}.{claimValor.Split('.')[1]}";
            ClaimApp claimApp;
            
            // Act
            claimApp = new ClaimApp(claimTipo, claimValor);

            //Assert
            Assert.Equal(claimTipo, claimApp.ClaimTipo);
            Assert.Equal(claimValor, claimApp.ClaimValor);
            Assert.Equal(claimNome, claimApp.Nome);
            Assert.Equal(resumo, claimApp.Resumo);
        }
    }
}
