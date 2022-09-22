using Microsoft.Extensions.Configuration;
using Pulsati.Core.Domain.Constantes;

namespace Pulsati.Core.Domain.Singletons.Ambiente
{
    public sealed class VariavelDeAmbiente
    {
        private static VariavelDeAmbiente _instancia;
        public static VariavelDeAmbiente InicializarSingleton(IConfiguration configuration)
        {
            if (_instancia == null)
            {
                try
                {
                    _instancia = new VariavelDeAmbiente(
                        configuration.GetConnectionString("DefaultConnection"),
                        configuration.GetSection("EnderecoRabbitMq").Value,
                        configuration.GetSection("EnderecoApiGateway").Value,
                        bool.Parse(configuration.GetSection("EstaEmDevDocker").Value)
                        );
                }
                catch (Exception erro)
                {
                    throw new Exception("Não foi possivel obter valor das variaveis de ambiente, veja mais dos erros nos detalhes", erro);
                }
            }
            return _instancia;
        }
        public static VariavelDeAmbiente ObterInstanciaInicializada()
        {
            if (_instancia == null)
                throw new Exception("Não é possivel obter a instancia das variaveis de ambiente sem antes ter incializado a mesma. Utilize o metodo InicializarSingleton preferencialmente na startup do projeto");
            return _instancia;
        }
        private VariavelDeAmbiente(string connectionString, string enderecoRabbitMq, string enderecoApiGateway, bool estaEmDevDocker)
        {
            ConnectionString = connectionString;
            EnderecoRabbitMq = enderecoRabbitMq;
            EnderecoApiGateway = enderecoApiGateway;
            EstaEmDevDocker = estaEmDevDocker;

            if (EstaEmDevDocker)
                ModificarEnderecoParaDocker();
        }

        

        public string ConnectionString { get; private set; }
        public string EnderecoRabbitMq { get; private set; }
        public string EnderecoApiGateway { get; private set; }
        public bool EstaEmDevDocker { get; private set; }
        private void ModificarEnderecoParaDocker()
        {
            ConnectionString = SubstituirEnderecoAcesso(ConnectionString);
            EnderecoRabbitMq = SubstituirEnderecoAcesso(ConnectionString);
            EnderecoApiGateway = SubstituirEnderecoAcesso(ConnectionString);
        }
        private static string SubstituirEnderecoAcesso(string enderecoAtual) => enderecoAtual.Replace(Constante.LOCALHOST, Constante.ENDERECO_DOCKER_ACESSA_LOCALHOST);
    }

}
