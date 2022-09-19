using Ioutility.Franquias.Domain.Franquias.Models;
using Pulsati.Core.Domain.Models;
using Pulsati.Core.Domain.ValueObjects.Enderecos;
using Pulsati.Core.Domain.ValueObjects.StringPesquisavel;
using Ioutility.Franquias.Domain.Franquias.Enums;

namespace Ioutility.Franquias.Domain.Franquias.Models
{
    public class Franquia : EntityBasic<Franquia>
    {
        // EF CORE
        protected Franquia()
        {

        }
        //FranquiaBusinessPay businessPay,
        public Franquia(Guid id, string nome, string razaoSocial, string matricula, string cnpj, string responsavelLegal, string email, string telefone
            , string celularWhatsApp, EnderecoVO endereco, FranquiaDadoBancario dadosBancarios,  FranquiaAcessoVO acesso) : base(id, nome)
        {
            RazaoSocial = razaoSocial;
            Matricula = matricula;
            Cnpj = cnpj;
            ResponsavelLegal = responsavelLegal;    
            Email = email;
            Telefone = telefone;
            CelularWhatsApp = celularWhatsApp;
            Endereco = endereco;
            DadosBancarios = dadosBancarios;
            //BusinessPay = businessPay;
            Acesso = acesso;
        }
        public string RazaoSocial { get; private set; }
        public string Matricula { get; private set; }
        public string Cnpj { get; private set; }
        public string ResponsavelLegal { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string CelularWhatsApp { get; private set; }
        public EnderecoVO Endereco { get; private set; }
        public FranquiaDadoBancario DadosBancarios { get; private set; }
        //public FranquiaBusinessPay BusinessPay { get; private set; }
        public FranquiaAcessoVO Acesso { get; private set; }
        public override string DisplayNameTypeOf() => "Franquia";

        public void SetStatus(EFranquiaStatus status)
        {
            Acesso.SetStatus(status);
        }

    }

}
