using Pulsati.Core.Domain.Models;
using Pulsati.Core.Domain.UnidadeTests.Models.Validacoes;
using System;
using System.Collections.Generic;

namespace Cn.Core.Domain.Tests.Models
{
    public class EntityTeste : Entity<EntityTeste>
    {
        public EntityTeste()
        {

        }

        public EntityTeste(Guid id,
            string textoObrigatorio, 
            string textoMinimo, 
            string textoMaximo, 
            DateTime data, 
            DateTime dataAtual, 
            string email, 
            IEnumerable<EntityDependenteTeste> dependentesObrigatorios, 
            IEnumerable<EntityDependenteTeste> dependentesNaoRepetidos,
            IEnumerable<EntityDependenteTeste> dependentesInvalidos) : base(id)
        {
            TextoObrigatorio = textoObrigatorio;
            TextoMinimo = textoMinimo;
            TextoMaximo = textoMaximo;
            Data = data;
            DataAtual = dataAtual;
            Email = email;
            DependentesObrigatorios = dependentesObrigatorios;
            DependentesNaoRepetidos = dependentesNaoRepetidos;
            DependentesInvalidos = dependentesInvalidos;
        }

        public string TextoObrigatorio { get; private set; }
        public string TextoMinimo { get; private set; }
        public string TextoMaximo { get; private set; }
        public DateTime Data { get; private set; }
        public DateTime DataAtual { get; private set; }
        public string Email { get; private set; }
        public IEnumerable<EntityDependenteTeste> DependentesObrigatorios { get; private set; }
        public IEnumerable<EntityDependenteTeste> DependentesNaoRepetidos { get; private set; }
        public IEnumerable<EntityDependenteTeste> DependentesInvalidos { get; private set; }

       
        public void SetId(Guid id)
        {
            Id = id;
        }
        public void SetTextoObrigatorio(string texto)
        {
            TextoObrigatorio = texto;
        }
        public void SetTextoMinimo(string texto)
        {
            TextoMinimo = texto;
        }
        public void SetTextoMaximo(string texto)
        {
            TextoMaximo= texto;
        }
        public void SetDataAtual(DateTime dataAtual )
        {
            DataAtual = dataAtual;
        }
        public void SetDataCoerente(DateTime data)
        {
            Data = data;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
        public void SetDependentesObrigatorios(IEnumerable<EntityDependenteTeste> dependentes)
        {
            DependentesObrigatorios = dependentes;
        }
        public void SetDependentesNaoRepetidos(IEnumerable<EntityDependenteTeste> dependentes)
        {
            DependentesNaoRepetidos = dependentes;
        }
        public void SetDependentesInvalidos(IEnumerable<EntityDependenteTeste> dependentes)
        {
            DependentesInvalidos = dependentes;
        }

        public override string DisplayNameTypeOf()
        {
            return "EntityTeste";
        }

        protected override void SetValidacoes()
        {
            AddValidacao(new EntityTesteValidacaoCommand(this));
            base.SetValidacoes();
        }
    }
}
