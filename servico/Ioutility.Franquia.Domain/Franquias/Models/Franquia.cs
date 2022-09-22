using Ioutility.Franquias.Domain.Franquias.Models;
using Pulsati.Core.Domain.Models;
using Pulsati.Core.Domain.ValueObjects.Enderecos;
using Pulsati.Core.Domain.ValueObjects.StringPesquisavel;
using Ioutility.Franquias.Domain.Franquias.Enums;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Interfaces.Entitys;

namespace Ioutility.Franquias.Domain.Franquias.Models
{
    public class Franquia : EntityBasic<Franquia>, IEntityComArquivo
    {
        // EF CORE
        protected Franquia()
        {

        }
        //FranquiaBusinessPay businessPay,
        public Franquia(Guid id, string imagemFranquia, string nome, string cnpj, string responsavelLegal, string email, string telefone
            , string celularWhatsApp, EnderecoVO endereco, DadoBancarioVO dadosBancarios, BusinessPayVO businessPay, FranquiaAcessoVO acesso) : base(id, nome)
        {
            ImagemFranquia = imagemFranquia;
            Nome = nome;
            Cnpj = cnpj;
            ResponsavelLegal = responsavelLegal;    
            Email = email;
            Telefone = telefone;
            CelularWhatsApp = celularWhatsApp;
            Endereco = endereco;
            DadosBancarios = dadosBancarios;
            BusinessPay = businessPay;
            Acesso = acesso;
            GerarCodigoVirtual();

        }
        public string ImagemFranquia { get; set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public string ResponsavelLegal { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string CelularWhatsApp { get; private set; }
        public EnderecoVO Endereco { get; private set; }
        public DadoBancarioVO DadosBancarios { get; private set; }        
        public BusinessPayVO BusinessPay { get; private set; }
        public FranquiaAcessoVO Acesso { get; private set; }

        public string CaminhoImagem { get => PastaImagemFranquia() + ImagemFranquia; }
        public string CodigoVirtual { get; private set; }
        public override string DisplayNameTypeOf() => "Franquia";

        public void SetStatus(EFranquiaStatus status)
        {
            Acesso.SetStatus(status);
        }

        private void GerarCodigoVirtual()
        {
            CodigoVirtual = Id.ToString().Split('-')[0] + DataCriacao.ToString("dd.MM.HH.ss");
            CodigoVirtual = CodigoVirtual.FormatarParaBusca();
        }


        public IReadOnlyCollection<InfoArquivoDTO> ObterTodosArquivosComDiretorio()
        {
            var imagemFranquia = ImagemFranquia.ConverterStringArquivosEmListaDeArquivos(PastaImagemFranquia());
            var todosArquivos = imagemFranquia;
            return todosArquivos;
        }

        public static string PastaImagemFranquia() => "franquia/imagem-franquia/";

    }

}
