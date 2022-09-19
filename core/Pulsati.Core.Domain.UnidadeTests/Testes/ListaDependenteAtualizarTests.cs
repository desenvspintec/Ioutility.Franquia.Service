using Cn.Core.Domain.Tests.Helpers;
using System;
using Xunit;
namespace Cn.Core.Domain.Tests.Testes
{
    public class ListaDependenteAtualizarTests
    {
        private readonly ListaDependenteAtualizarHelper _helper;
        private static string _baseMensagemErro = "A entidade  não pode ser atualizada, pois ";
        private readonly string MensagemErroRegistrarNulo = _baseMensagemErro + "a lista registrar é nula";
        private readonly string MensagemErroRemoverNulo = _baseMensagemErro + "a lista remover é nula";
        
        public ListaDependenteAtualizarTests()
        {
            _helper = new ListaDependenteAtualizarHelper();
        }

        //[Fact(DisplayName = "1 - Lista Valida")]
        //[Trait("Categoria", "Core Domain 4 - Lista dependente")]
        //public void New_EhValida_DeveConterAsListasCorretas()
        //{
        //    // Arrange
        //    var dependentes = _helper.ObterListaValida();

        //    // Act
        //    // -> acontece no construtor

        //    // Assert
        //    Assert.Equal(_helper.ListaRemover, dependentes.ListaRemover);
        //    Assert.Equal(_helper.ListaRegistrar, dependentes.ListaRegistrar);
        //}


        //[Fact(DisplayName = "2 - Lista Invalida - Remover nulo")]
        //[Trait("Categoria", "Core Domain 4 - Lista dependente")]
        //public void New_Invalida_DeveLancarExceptionAoVerListaRemoverNula()
        //{
        //    var exception = Assert.Throws<Exception>(() => _helper.ObterListaRemoverNulo());
        //    Assert.Equal(exception.Message, MensagemErroRemoverNulo);
        //}
        //[Fact(DisplayName = "3 - Lista Invalida - Regitrar nulo")]
        //[Trait("Categoria", "Core Domain 4 - Lista dependente")]
        //public void New_Invalida_DeveLancarExceptionAoVerListaRegistrarNula()
        //{
        //    var exception = Assert.Throws<Exception>(() => _helper.ObterListaRegistrarNulo());
        //    Assert.Equal(exception.Message, MensagemErroRegistrarNulo);
        //}
     
    }
}
