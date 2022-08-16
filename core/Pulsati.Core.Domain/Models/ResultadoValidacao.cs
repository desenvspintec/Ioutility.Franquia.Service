namespace Pulsati.Core.Domain.Models
{
    public class ResultadoValidacao
    {
        private readonly List<string> _erros;

        private ResultadoValidacao(bool estaValido)
        {
            _erros = new List<string>();
            EstaValido = estaValido;
        }

        public bool EstaValido { get; private set; }
        public List<string> ObterErros(bool removerRepetidos = true)
        {
            var resultado = _erros.ToList();
            if (removerRepetidos)
                return resultado.Distinct().ToList();

            return resultado;
        }

        public static ResultadoValidacao ObterValido() => new(true);
        public static ResultadoValidacao ObterComErro(string erro)
        {
            var resultado = new ResultadoValidacao(false);
            resultado._erros.Add(erro);
            return resultado;
        }
        public static ResultadoValidacao ObterComErros(IEnumerable<string> erros)
        {
            var resultado = new ResultadoValidacao(false);
            resultado._erros.AddRange(erros);

            return resultado;
        }

        public void AddErros(IEnumerable<string> erros)
        {
            EstaValido = !erros.Any();
            _erros.AddRange(erros);
        }
    }
}
