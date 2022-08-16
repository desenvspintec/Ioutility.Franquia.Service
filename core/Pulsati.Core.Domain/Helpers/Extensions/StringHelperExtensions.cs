using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Enums;
using System.Globalization;
using System.Text;

namespace Pulsati.Core.Domain.Helpers.Extensions
{
    public static class StringHelperExtensions
    {
        public static string FormatarParaNome(this string nomeCompleto)
        {
            if (!nomeCompleto.EstaPreenchido()) return nomeCompleto;

            var nomeCompletoFormatado = "";

            nomeCompleto = nomeCompleto.ToLower();
            nomeCompleto = nomeCompleto.RemoverEspacosDesnecessarios();

            var nomes = nomeCompleto.Split(' ');
            foreach (var nome in nomes)
            {
                if (nome.EhPreposicao())
                {
                    nomeCompletoFormatado += nome + " ";
                    continue;
                };
                var primeiraLetraDoNome = nome.Substring(0, 1).ToUpper();
                var restoDoNome = _nomePossuiUmResto(nome) ? nome[1..] : "";
                var nomeFormatado = primeiraLetraDoNome + restoDoNome;
                nomeCompletoFormatado += nomeFormatado + " ";
            }
            nomeCompletoFormatado = nomeCompletoFormatado.RemoverUltimoCaracter();
            return nomeCompletoFormatado;

        }

        private static bool _nomePossuiUmResto(string nome)
        {
            return nome.Length > 1;
        }

        public static string RemoverPreposicao(this string textoFiltrar)
        {
            var preprosicoes = Constante.Preposicoes;

            textoFiltrar = CorrigirNulo(textoFiltrar);
            preprosicoes.ForEach(preposicao => textoFiltrar = textoFiltrar.Replace(preposicao, " "));

            return textoFiltrar;
        }

        public static bool EhPreposicao(this string texto)
        {
            texto = texto.FormatarParaBusca().RemoverPrimeiroEUltimoEspaco();
            foreach (var preposicao in Constante.Preposicoes)
                if (preposicao.RemoverPrimeiroEUltimoEspaco() == texto) return true;

            return false;
        }
        public static string RemoverEspacosDesnecessarios(this string textoFiltrar)
        {
            textoFiltrar = CorrigirNulo(textoFiltrar);
            var textoFiltrado = textoFiltrar.Replace("  ", " ");
            textoFiltrado = textoFiltrado.Replace("  ", " ").Trim();
            textoFiltrado = _removerPrimeiroEUltimoEspaco(textoFiltrado);

            return textoFiltrado;
        }

        private static string _removerPrimeiroEUltimoEspaco(string textoFiltrar)
        {
            if (textoFiltrar.Length == 0) return textoFiltrar;
            textoFiltrar = textoFiltrar.Trim();

            if (textoFiltrar.Substring(0, 1) == " ")
                textoFiltrar = textoFiltrar[1..];

            var textoFicouVazio = textoFiltrar.Length == 0;
            if (textoFicouVazio) return textoFiltrar;

            if (textoFiltrar.Substring(textoFiltrar.Length - 1, 1) == " ")
                textoFiltrar = textoFiltrar[0..^1];

            return textoFiltrar;
        }
        public static string RemoverPrimeiroEUltimoEspaco(this string textoFiltrar)
        {
            return _removerPrimeiroEUltimoEspaco(textoFiltrar);
        }
        /// <summary>
        /// Remove espaços descenecesarios, acentos e transforma a string totalmente em minuscula
        /// </summary>
        /// <param name="textoFormatar">texto a ser formatado</param>
        /// <returns>texto filtrado</returns>
        public static string FormatarParaBusca(this string textoFormatar)
        {
            textoFormatar = textoFormatar.CorrigirNulo();
            textoFormatar = textoFormatar.RemoverAcentos();
            var textoFormatado = textoFormatar.RemoverEspacosDesnecessarios().ToLower();

            return textoFormatado;
        }

        public static string FormatarParaBuscaFiltrandoPreposicao(this string textoFormatar)
        {
            textoFormatar = textoFormatar.CorrigirNulo();
            var textoFormatado = textoFormatar.FormatarParaBusca();
            textoFormatado = textoFormatado.RemoverPreposicao();
            textoFormatado = textoFormatado.RemoverEspacosDesnecessarios();
            return textoFormatado;
        }

        /// <summary>
        /// Função evita que acorram exception  por causa de string nula
        /// </summary>
        /// <param name="texto">string a verificar se é nula</param>
        /// <returns>string vazia ("") caso o texto passado por parametro seja null</returns>
        public static string CorrigirNulo(this string texto)
        {
            return texto ?? "";
        }
        public static string RemoverUltimosCaracteresDeString(string textoFormatar, string textoSerRemovido)
        {
            if (string.IsNullOrEmpty(textoFormatar)) return textoFormatar;
            if (textoFormatar.Length < textoSerRemovido.Length) return textoFormatar;

            var tamanhoCorreto = textoFormatar.Length - textoSerRemovido.Length;
            var textoFormatado = textoFormatar.Substring(0, tamanhoCorreto);

            return textoFormatado;
        }

        public static List<string> ConverterEmList(this string textoConverter, string separador)
        {
            List<string> lista = textoConverter.Split(new string[] { separador }, StringSplitOptions.None).ToList();

            return lista;
        }

        public static string ConverterListEmString(this IEnumerable<string> lista, string separador = ", ")
        {
            bool listaVazia = lista == null;
            if (listaVazia) return "";

            string listaEmTexto = "";

            foreach (var item in lista)
                listaEmTexto += item + ", ";
            bool textoFoiPreenchido = !listaEmTexto.Any();
            if (textoFoiPreenchido) return listaEmTexto;

            listaEmTexto = RemoverUltimosCaracteresDeString(listaEmTexto, separador);
            return listaEmTexto;
        }
        public static string RemoverAcentos(this string text)
        {
            var sbReturn = new StringBuilder();

            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static string FormatarParaNomeArquivo(this string text)
        {
            text = FormatarParaBusca(text);
            text = text.Replace("'", "");
            text = text.Replace("/", "");
            text = text.Replace("\\", "");
            text = text.Replace(":", "");
            text = text.Replace("<", "");
            text = text.Replace(">", "");
            text = text.Replace("*", "");
            text = text.Replace("|", "");
            text = text.Replace("?", "");
            return text;
        }

        public static string ConvertASCII(this string stringConverter)
        {
            byte[] byteString = Encoding.ASCII.GetBytes(stringConverter);
            var stringASCII = Encoding.ASCII.GetString(byteString);

            return stringASCII;
        }

        public static bool EstaPreenchido(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return false;
            return true;
        }

        public static string FormatarNumeroParaFormatoAmericano(this string numeroToString)
        {
            var numeracaoEmTexto = numeroToString;

            string caracterParaDarSplit = "";
            if (numeracaoEmTexto.Contains(",")) caracterParaDarSplit = ",";
            if (numeracaoEmTexto.Contains(".")) caracterParaDarSplit = ".";
            if (caracterParaDarSplit.Length == 0) return "";

            var txtNumeroAposVirgula = numeracaoEmTexto.Split(Convert.ToChar(caracterParaDarSplit))[1];
            var txtNumeroAntesVirgula = numeracaoEmTexto.Split(Convert.ToChar(caracterParaDarSplit))[0];
            return txtNumeroAntesVirgula + "." + txtNumeroAposVirgula;
        }

        public static string ConverterCaminhoArquivoParaApi(this string caminho)
        {
            return caminho.Replace("/", "--");
        }
        public static string DesconverterCaminhoArquivoParaApi(this string caminho)
        {
            return caminho.Replace("--", "/");
        }

        public static string ObterExtensao(this string nomeArquivo)
        {
            if (!nomeArquivo.EstaPreenchido()) return "";

            var arquivoDivido = nomeArquivo.Split('.');
            if (arquivoDivido.Length == 0) return "";

            return arquivoDivido[^1];


        }

        public static string ObterNomeArquivo(this string nomeArquivo)
        {
            if (!nomeArquivo.EstaPreenchido()) return "";

            var arquivoDivido = nomeArquivo.Split('/');
            if (arquivoDivido.Length == 0) return "";

            return arquivoDivido[^1];
        }
        public static IReadOnlyCollection<InfoArquivoDTO> ConverterStringArquivosEmListaDeArquivos(this string nomesArquivosString, string diretorio)
        {
            var lista = new List<InfoArquivoDTO>();
            if (!nomesArquivosString.EstaPreenchido()) return lista;

            var nomesArquivos = nomesArquivosString.SepararEmList();
            if (!nomesArquivos.Any()) return lista;

            foreach (var nomeArquivo in nomesArquivos)
            {
                var arquivoFormatado = nomeArquivo.FormatarParaNomeArquivo();
                var infoArquivo = new InfoArquivoDTO(diretorio, arquivoFormatado, arquivoFormatado.ObterExtensao());
                lista.Add(infoArquivo);
            }

            return lista;
        }
        public static List<string> SepararEmList(this string textoConverter, string separador = ArquivoHelper.SEPARADOR_STRING_EM_LIST)
        {
            if (!textoConverter.EstaPreenchido()) return new List<string>();
            List<string> lista = textoConverter.Split(new string[] { separador }, StringSplitOptions.None).ToList();

            return lista;
        }

        public static string ObterPastaArquivo(this string diretorio)
        {
            if (!diretorio.EstaPreenchido()) return "";

            var diretorioDivido = diretorio.Split('/');
            if (diretorioDivido.Length == 0) return "";

            var pastaArquivo = "";
            for (int i = 0; i < diretorioDivido.Length - 1; i++)
                pastaArquivo += diretorioDivido[i] + "/";

            return pastaArquivo;
        }

        public static string FormatarParaPastaComBarraNoFinal(this string pasta)
        {
            if (pasta.UltimoCaracter() == "/") return pasta;

            return pasta + "/";
        }
        public static string UltimoCaracter(this string texto)
        {
            if (!texto.EstaPreenchido()) return "";

            return texto.Substring(texto.Length - 1, 1);
        }
        public static string RemoverUltimoCaracter(this string texto)
        {
            if (!texto.EstaPreenchido()) return "";

            return texto[0..^1];
        }

    }
}
