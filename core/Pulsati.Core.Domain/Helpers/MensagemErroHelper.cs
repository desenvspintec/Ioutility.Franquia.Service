namespace Pulsati.Core.Domain.Helpers
{
    public static class MensagemErroHelper
    {
        public static string EmailNaoValido(string propriedade = "E-mail")
        {
            var msg = $"o campo {propriedade} não possui um e-mail valido";

            return msg;
        }
        public static string DeveSerNulo(string propriedade, string justificativa = "")
        {
            var msg = $"{propriedade} não pode ser preenchido(a)";

            if (!string.IsNullOrEmpty(justificativa))
            {
                msg += " " + justificativa;
            }

            return msg;
        }
        public static string NaoNulo(string propriedade)
        {
            var msg = $"{propriedade} não pode ser nulo(a)";

            return msg;
        }

        public static string ArquivoNaoEncontradoNaPastaTemporaria()
        {
            return "Não foi possivel continuar. Por favor, realize novamente o upload de arquivos";
        }

        public static string MinLength(string propriedade, int tamanhoMinimo)
        {
            var msg = $"{propriedade} deve possuir no minimo {tamanhoMinimo} caracteries";

            return msg;
        }



        public static string MaxLength(string propriedade, int tamanhoMaximo)
        {
            var msg = $"{propriedade} não pode ter mais que {tamanhoMaximo} caracteries";

            return msg;
        }

        public static string DataMaiorQue(string propriedade, DateTime data)
        {
            var msg = $"{propriedade} necessita que seja posterior à {data.ToString("dd/MM/yyyy")}";

            return msg;
        }
        public static string DataMenorQue(string propriedade, DateTime data)
        {
            var msg = $"{propriedade} necessita que seja anterior à {data.ToString("dd/MM/yyyy")}";

            return msg;
        }

        internal static string NaoPreenchido(string nomePropriedade)
        {
            var msg = $"{nomePropriedade} deve ser preenchido(a)";

            return msg;
        }

        public static string NumeroMinimo(string propriedade, int numeroMinimo)
        {
            var msg = $"{propriedade} deve ser maior que {numeroMinimo}";

            return msg;
        }
        public static string NumeroMaximo(string propriedade, int numeroMaximo)
        {
            var msg = $"{propriedade} deve ser menor que {numeroMaximo}";

            return msg;
        }

        public static string NumeroDocumento()
        {
            var msg = $"O Nº de documento não esta valido ";

            return msg;
        }

        public static string Invalido(string nomePropriedade)
        {
            return $"{nomePropriedade} esta invalido";
        }

        public static string CnpjInvalido(string cnpj)
        {
            var msg = $"O CNPJ '{cnpj}' não esta valido ";

            return msg;
        }

        public static string NaoNuloLista(string propriedade)
        {
            var msg = $"Adicione pelo menos um {propriedade} ";

            return msg;
        }

        public static string ListaRepetida(string propriedade)
        {
            var msg = $"Não é possivel haver {propriedade} duplicados. ";

            return msg;
        }
        public static string CeiInvalido(string cei)
        {
            var msg = $"o CEI '{cei}' não esta valido ";

            return msg;
        }

        public static string EntityRepetida(string chave)
        {
            var msg = $"{chave} já esta cadastrado(a) e não pode ser duplicado";

            return msg;
        }
        public static string NaoIgual(string propriedade, string valor)
        {
            var msg = $"{propriedade} não pode ser igual a {valor} ";

            return msg;
        }

        public static string Igual(string propriedade, string valor)
        {
            var msg = $"{propriedade} deve ser igual a {valor} ";

            return msg;
        }
    }
}
