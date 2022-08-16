using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Pulsati.Core.Domain.Models
{
    public abstract class EntityBasic<TEntity> : Entity<TEntity>, IEntityBasic where TEntity : EntityBasic<TEntity>, IEntityBasic
    {
        protected EntityBasic() {}
        public EntityBasic(Guid id, string nome) : base(id)
        {
            SetNome(nome);
        }

        public string Nome { get; private set; }
        public string NomeQuery { get; private set; }
        public string NomeSemPreposicaoQuery { get; private set; }

        protected void SetNome(string nome)
        {
            if (FormatarIniciaisEmMaiusculo()) Nome = nome.FormatarParaNome();
            else Nome = nome;

            NomeQuery = nome.FormatarParaBusca();
            NomeSemPreposicaoQuery = nome.FormatarParaBuscaFiltrandoPreposicao();
        }

        public virtual bool FormatarIniciaisEmMaiusculo() => true;
        protected override void SetValidacoes()
        {
            AddValidacao(new ValidarNomeCommand<TEntity>((TEntity)this));
            base.SetValidacoes();
        }
    }
}
