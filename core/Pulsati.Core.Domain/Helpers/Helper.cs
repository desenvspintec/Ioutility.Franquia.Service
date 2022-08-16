using Microsoft.Extensions.Configuration;

namespace Pulsati.Core.Domain.Helpers
{
    public class Helper
    {
        public static int ConverterDataNascimentoEmIdade(DateTime dataNascimento)
        {
            var dataAtual = DateTime.Today;

            var idade = dataAtual.Year - dataNascimento.Year;

            // Volta o ano em caso de ano bissexto
            if (dataNascimento.Date > dataAtual.AddYears(-idade)) idade--;

            return idade;
        }

        public static string ObterNomeClasse<TEntity>() => typeof(TEntity).ToString().Split('.').Last();

        public static string ObterValorEnviroumant(string sessaoEnviroumant)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var sessao = config.GetSection(sessaoEnviroumant);
            return sessao.Value;
        }
    }
}
