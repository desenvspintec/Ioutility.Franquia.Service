using Pulsati.Core.Domain.Helpers;

namespace Pulsati.Core.Domain.Constantes
{
    public static class Constante
    {
        public const int MAX_LEN_PADRAO = 100;
        public const int MIN_LEN_PADRAO = 2;
        public const int QUANTITADE_CARACTERIES_PARA_TELEFONE =11;
        public const int QUANTITADE_CARACTERIES_PARA_CPF =14;
        public const int QUANTITADE_CARACTERIES_PARA_CNPJ =18;

        public const int QUANTITADE_CARACTERIES_PARA_PIS = 14;
        public const int QUANTITADE_CARACTERIES_PARA_RG = 14;

        public const string SEPARADOR_DOMAIN_VALIDACAO = "||";

        public static DateTime DATA_MINIMA_PARA_SER_CORENTE => new(1920, 1, 1);
        public static DateTime DATA_ATUAL => DateTime.Today;
        public static DateTime DATA_UM_ANO_ANTES => DATA_ATUAL.AddYears(-1);
        public static DateTime DATA_MINIMA_CADASTRO_PESSOA_MAIOR_DE_IDADE => DATA_ATUAL.AddYears(-16);
        public static List<string> Preposicoes => new() { " da ", " de ", " das ", " do ", " dos ", " em ", " no ", " na " };

        public const string PASTA_TEMPORARIA = "tmp/";

        public const string ERRO_AO_VALIDAR_NA_ENTIDADE_DE_DOMINIO = "Erro de entidade de dominio";

        public const string CAMINHO_PADRAO = "/wwwroot/" + PASTA_TEMPORARIA;
        public static string STORAGE_SERVICE_ARQUIVOS_STATICOS = "https://localhost:7041/" + ArquivoHelper.ObterDiretorioArquivosStaticos();
        public const string STORAGE_SERVICE = "https://localhost:7041/";
        public const string STORAGE_SERVICE_API = STORAGE_SERVICE + "api/Storage/";
    }
}
