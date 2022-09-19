using Pulsati.Core.Domain.Bus.MessagesDTO.Storage;
using Pulsati.Core.Domain.Constantes;
using Xunit;

namespace Pulsati.Core.Domain.UnidadeTests.Testes.StorageServices
{
    public class MoverArquivoCommandTests
    {
        [Fact(DisplayName = "1 - Instanciar MoverArquivoCommand para pasta tmp")]
        [Trait("Categoria", "Core Domain 5 - StorageService")]
        public void InstanciarParaPastaTmp_DeveInicializarComSucesso_DeveAdequarOsDadosConformeRegra()
        {
            // Arrange
            var nomeArquivo = "arquivoTeste.pdf";
            var nomeArquivoAposMover = "arquivoTeste2.pdf";
            var nomePasta = "pastaTeste/";
            var caminhoAtual = nomePasta + nomeArquivo;
            var caminhoMover = Constante.PASTA_TEMPORARIA + nomeArquivoAposMover;
            const bool copiar = true;
            const bool substituir = true;
            const bool ignorarErros = false;
            var descricao = $"arquivo de origem {caminhoAtual} para {caminhoMover}. Parametros: Substituir: {substituir}, Copiar: {copiar}, ignorar erros: {ignorarErros}";
            MoverArquivoCommand command;
            
            // Act
            command = MoverArquivoCommand.DisponibilizarNaTmp(nomeArquivo, nomePasta, nomeArquivoAposMover);

            // Assert
            Assert.Equal(caminhoAtual, command.CaminhoAtual);
            Assert.Equal(caminhoMover, command.CaminhoMover);
            Assert.Equal(copiar, command.Copiar);
            Assert.Equal(substituir, command.Substituir);
            Assert.Equal(ignorarErros, command.IgnorarErros);
            Assert.Equal(ignorarErros, command.IgnorarErros);
            Assert.Equal(descricao, command.Descricao());
        }
        [Fact(DisplayName = "2 - Instanciar MoverArquivoCommand partindo da pasta tmp")]
        [Trait("Categoria", "Core Domain 5 - StorageService")]
        public void InstanciarPartindoPastaTmp_DeveInicializarComSucesso_DeveAdequarOsDadosConformeRegra()
        {
            // Arrange
            var nomeArquivo = "arquivoTeste.pdf";
            var nomePasta = "pastaTeste/";
            var caminhoAtual = Constante.PASTA_TEMPORARIA + nomeArquivo;
            var caminhoMover = nomePasta + nomeArquivo;
            const bool copiar = false;
            const bool substituir = true;
            const bool ignorarErros = false;
            MoverArquivoCommand command;

            // Act
            command = MoverArquivoCommand.MoverAPartirDaTmpFactory(nomeArquivo, nomePasta);

            // Assert
            Assert.Equal(caminhoAtual, command.CaminhoAtual);
            Assert.Equal(caminhoMover, command.CaminhoMover);
            Assert.Equal(copiar, command.Copiar);
            Assert.Equal(substituir, command.Substituir);
            Assert.Equal(ignorarErros, command.IgnorarErros);
        }
    }
}
