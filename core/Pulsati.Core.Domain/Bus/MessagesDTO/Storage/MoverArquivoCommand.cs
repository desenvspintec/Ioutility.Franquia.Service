using Pulsati.Core.Domain.Constantes;

namespace Pulsati.Core.Domain.Bus.MessagesDTO.Storage
{
    public class MoverArquivoCommand
    {
        public MoverArquivoCommand()
        {
            Substituir = false;
            Copiar = false;
            IgnorarErros = false;
        }
        public string CaminhoAtual { get; set; }
        public string CaminhoMover { get; set; }
        public bool Substituir { get; set; }
        public bool Copiar { get; set; }
        public bool IgnorarErros { get; set; }

        public string Descricao()
        {
            return $"arquivo de origem {CaminhoAtual} para {CaminhoMover}. Parametros: Substituir: {Substituir}, Copiar: {Copiar}, ignorar erros: {IgnorarErros}";
        }
        /// <summary>
        /// as variaveis de diretorio devem terminar com uma BARRA "/" no final
        /// </summary>
        /// <param name="nomeArquivo"></param>
        /// <param name="caminhoOndeSeraSalvo"></param>
        /// <param name="nomeArquivoAposSalvado"></param>
        /// <param name="substituir"></param>
        /// <param name="copiar"></param>
        /// <returns></returns>
        public static MoverArquivoCommand MoverAPartirDaTmpFactory(string nomeArquivo, string caminhoOndeSeraSalvo, string nomeArquivoAposSalvado = "")
        {
            nomeArquivoAposSalvado = _obterNomeArquivoAposSalvar(nomeArquivo, nomeArquivoAposSalvado);
            return new MoverArquivoCommand()
            {
                CaminhoAtual = Constante.PASTA_TEMPORARIA + nomeArquivo,
                CaminhoMover = caminhoOndeSeraSalvo + nomeArquivoAposSalvado,
                Copiar = false,
                Substituir = true
            };
        }

        private static string _obterNomeArquivoAposSalvar(string nomeArquivo, string nomeArquivoAposSalvado)
        {
            nomeArquivoAposSalvado = nomeArquivoAposSalvado.Any() ? nomeArquivoAposSalvado : nomeArquivo;
            return nomeArquivoAposSalvado;
        }

        public static MoverArquivoCommand DisponibilizarNaTmp(string nomeArquivo, string caminhoOndeEstaSalvo, string nomeAposDisponibilizadoNaTmp = "")
        {
            nomeAposDisponibilizadoNaTmp = _obterNomeArquivoAposSalvar(nomeArquivo, nomeAposDisponibilizadoNaTmp);
            return new MoverArquivoCommand()
            {
                CaminhoAtual = caminhoOndeEstaSalvo + nomeArquivo,
                CaminhoMover = Constante.PASTA_TEMPORARIA + nomeAposDisponibilizadoNaTmp,
                Copiar = true,
                Substituir = true
            };
        }
    }
}
