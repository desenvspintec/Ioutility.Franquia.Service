using Cn.Core.Domain.Tests.Models;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cn.Core.Domain.Tests.Helpers
{
    public class EntityTesteHelper
    {
        public const int NUMERO_MAXIMO_DE_ERROS = 12;
        private const string TEXTO_MINIMO_VALIDO = "te";
        private const string TEXTO_MAXIMO_VALIDO = "teste teste testeteste teste testeteste teste testeteste teste testeteste teste testeteste teste tes";

        public EntityTeste ObterEntityValidaComListaDeDependentesNaoRepetidosNulo()
        {
            var entityId = Guid.NewGuid();
            var entitysDependentes = _obterEntitysDependentes(entityId);
            var entity = new EntityTeste(entityId
                , "texto obrigatorio válido"
                , TEXTO_MINIMO_VALIDO
                , TEXTO_MAXIMO_VALIDO
                , DateTime.Now
                , DateTime.Now
                , "a@a.com"
                , entitysDependentes.ToList()
                , entitysDependentes.ToList()
                , entitysDependentes.ToList());
            return entity;
        }
        public EntityTeste ObterEntityValidaComListaDeDependentesNaoRepetidosNula()
        {
            var entity = ObterEntityValidaComListaDeDependentesNaoRepetidosNulo();
            entity.SetDependentesNaoRepetidos(null);
            return entity;
        }

        private static List<EntityDependenteTeste> _obterEntitysDependentes(Guid entityId)
        {
            var entityDependente1 = new EntityDependenteTeste(Guid.NewGuid(), entityId, Guid.NewGuid());
            var entityDependente2 = new EntityDependenteTeste(Guid.NewGuid(), entityId, Guid.NewGuid());
            var entitysDependentes = new List<EntityDependenteTeste>() { entityDependente1, entityDependente2 };
            return entitysDependentes;
        }

        public EntityTeste ObterEntityTotalmenteInvalidaComDependentesObrigatoriosNulos()
        {
            var entity = ObterEntityValidaComListaDeDependentesNaoRepetidosNulo();
            
            var textoMaximoValido = TEXTO_MAXIMO_VALIDO + "t";
            var textoMinimoInvalido = TEXTO_MINIMO_VALIDO[0..^1];
            DateTime dataDeUmDiaAnterior = DateTime.Today.AddDays(-1);

            entity.SetId(Guid.Empty);
            entity.SetTextoObrigatorio(null);
            entity.SetTextoMinimo(textoMinimoInvalido);
            entity.SetTextoMaximo(textoMaximoValido);
            entity.SetEmail("aaa");
            entity.SetDataAtual(dataDeUmDiaAnterior);
            entity.SetDataCoerente(new DateTime(1919, 12, 31));
            entity.SetDependentesObrigatorios(null);
            entity.SetDependentesNaoRepetidos(_obterEntitysDependentesRepetidos(entity.Id));
            entity.SetDependentesInvalidos(_obterEntitysDependentesComApenasUmInvalidos(entity.Id));
            return entity;
        }
        public EntityTeste ObterEntityTotalmenteInvalidaComDependentesObrigatoriosVazio()
        {
            var entity = ObterEntityTotalmenteInvalidaComDependentesObrigatoriosNulos();
            entity.SetDependentesObrigatorios(new List<EntityDependenteTeste>());
            return entity;
        }
        private static List<EntityDependenteTeste> _obterEntitysDependentesRepetidos(Guid entityId)
        {
            var chaveRepetir = Guid.NewGuid();
            var entityDependente1 = new EntityDependenteTeste(Guid.NewGuid(), entityId, chaveRepetir);
            var entityDependente2 = new EntityDependenteTeste(Guid.NewGuid(), entityId, chaveRepetir);
            var entitysDependentes = new List<EntityDependenteTeste>() { entityDependente1, entityDependente2 };
            return entitysDependentes;
        }
        private static List<EntityDependenteTeste> _obterEntitysDependentesComApenasUmInvalidos(Guid entityId)
        {
            var chaveRepetir = Guid.NewGuid();
            var entityDependente1 = new EntityDependenteTeste(Guid.Empty, entityId, chaveRepetir);
            var entityDependente2 = new EntityDependenteTeste(Guid.NewGuid(), entityId, chaveRepetir);
            var entitysDependentes = new List<EntityDependenteTeste>() { entityDependente1, entityDependente2 };
            return entitysDependentes;
        }

        public string ObterErroDeEntityInvalida(ResultadoValidacao resultado, string mensagemErro)
        {
            var errosDescricao = resultado.ObterErros().Select(erro => erro.Split(Constante.SEPARADOR_DOMAIN_VALIDACAO)[1]);
            var erro = errosDescricao.FirstOrDefault(erro => erro == mensagemErro);
            if (erro == null) return "";
            return erro;
        }
    }
}
