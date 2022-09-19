using Cn.Core.Domain.Tests.Models;
using Pulsati.Core.Domain.Services.Validacao.Command;
using System.Linq;

namespace Pulsati.Core.Domain.UnidadeTests.Models.Validacoes
{
    public class EntityTesteValidacaoCommand : BaseEntityValidacaoCommand<EntityTeste>
    {
        public EntityTesteValidacaoCommand(EntityTeste entity) : base(entity)
        {

        }

        public override void PreencherRegrasValidacao()
        {
            ValidarCampoTextoBasico(entity => entity.TextoObrigatorio, "Texto Obrigatorio");
            ValidarCampoTextoBasico(entity => entity.TextoMinimo, "", false);
            ValidarCampoTextoBasico(entity => entity.TextoMaximo, "", false);
            ValidarDataCoerente(entity => entity.Data);
            ValidarDataMinimaAtual(entity => entity.DataAtual, "Data Atual");
            ValidarEmail(entity => entity.Email);
            ValidarListaDependente(entity => entity.DependentesObrigatorios);
            ValidarListaDependenteDuplicada(entity => entity.DependentesNaoRepetidos.Select(dep => dep.EntityTeste2Id), "Dependentes não repetidos");
            ValidarListaDependente(entity => entity.DependentesInvalidos);
        }
    }
}
