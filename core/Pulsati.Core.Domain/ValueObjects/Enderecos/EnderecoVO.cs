using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.DTOs.ValueObjects;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Validacoes;

namespace Pulsati.Core.Domain.ValueObjects.Enderecos
{
    public class EnderecoVO : IObjectComDomainValidacao<EnderecoVO>, IEntityComArquivo
    {
        // EF
        protected EnderecoVO()
        {
        }
        public EnderecoVO(string complemento, int? numero, string logradouro, string bairro, string cidade, string estado, string uf, string cep, string? arquivos)
        {
            Complemento = complemento;
            Numero = numero;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Uf = uf;
            Cep = cep;
            Arquivos = arquivos ?? "";
        }
        public EnderecoVO(EnderecoVODTO enderecoDto)
        {
            if (enderecoDto == null) return;
            Complemento = enderecoDto.Complemento;
            Numero = enderecoDto.Numero ?? 0;
            Logradouro = enderecoDto.Logradouro;
            Bairro = enderecoDto.Bairro;
            Cidade = enderecoDto.Cidade;
            Estado = enderecoDto.Estado;
            Uf = enderecoDto.Uf;
            Cep = enderecoDto.Cep;
            Arquivos = enderecoDto.Arquivos ?? "";
        }


        public string Complemento { get; private set; }
        public int? Numero { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Uf { get; private set; }
        public string Cep { get; private set; }
        public string Arquivos { get; private set; }

        public IEnumerable<IValidadorDomainCommand<EnderecoVO>> ObterDomainValidadorCommands()
        {
            return new List<IValidadorDomainCommand<EnderecoVO>>()
            {
                new EnderecoVOValidacaoCommand(this)
            };

        }

        public IReadOnlyCollection<InfoArquivoDTO> ObterTodosArquivosComDiretorio()
        {
            var arquivos = Arquivos.ConverterStringArquivosEmListaDeArquivos(PastaComprovante());
            return arquivos;
        }
        public static string PastaComprovante() => "comprovantes-residencia/";

    }
}
