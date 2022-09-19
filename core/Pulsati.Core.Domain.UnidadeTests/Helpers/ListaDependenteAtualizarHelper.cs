using System.Collections.Generic;

namespace Cn.Core.Domain.Tests.Helpers
{
    public class ListaDependenteAtualizarHelper
    {
        public List<EntityDependenteParaAtualizarTeste> ListaRemover;
        public List<EntityDependenteParaAtualizarTeste> ListaRegistrar;
        public List<EntityDependenteParaAtualizarTeste> ListaRegistrarComUmAMais;

        public ListaDependenteAtualizarHelper()
        {
            ListaRemover = new List<EntityDependenteParaAtualizarTeste> { new EntityDependenteParaAtualizarTeste { teste = 1 }, new EntityDependenteParaAtualizarTeste { teste = 2 } };
            ListaRegistrar = new List<EntityDependenteParaAtualizarTeste> { new EntityDependenteParaAtualizarTeste { teste = 1 }, new EntityDependenteParaAtualizarTeste { teste = 2 } };
            ListaRegistrarComUmAMais = new List<EntityDependenteParaAtualizarTeste> { new EntityDependenteParaAtualizarTeste { teste = 1 }, new EntityDependenteParaAtualizarTeste { teste = 2 }, new EntityDependenteParaAtualizarTeste { teste = 3 } };

        }
        //public ListaDependenteAtualizar ObterListaValida() => new ListaDependenteAtualizar(ListaRemover, ListaRegistrar);
        //public ListaDependenteAtualizar ObterListaRegistrarNulo() => new ListaDependenteAtualizar(ListaRemover, null);
        //public ListaDependenteAtualizar ObterListaRemoverNulo() => new ListaDependenteAtualizar(null, ListaRegistrar);
        //public ListaDependenteAtualizar ObterListaInvalidaQuantidadesDiferentes() => new ListaDependenteAtualizar(ListaRemover, ListaRegistrarComUmAMais);
    }

    public class EntityDependenteParaAtualizarTeste //: IEntityDependenteParaAtualizar
    {
        public int teste;

        public void SetarNullEntityPai()
        {
            
        }
    }
}
