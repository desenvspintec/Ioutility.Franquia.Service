using Pulsati.Core.Domain.Interfaces.Entitys;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Services.Validacao.Command;

namespace Pulsati.Core.Domain.Models
{
    public abstract class Entity<TEntity> : IEntityComDomainValidacao<TEntity> where TEntity : Entity<TEntity>, IEntity
    {
        protected Entity()
        {
        }
        protected Entity(Guid id)
        {
            Id = id;
            DataCriacao = DateTime.Now;
            Ativo = true;
        }
        public Guid Id { get; protected set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime? DataInativacao { get; private set; }

        public bool Ativo { get; private set; }

        public abstract string DisplayNameTypeOf();

        public void Inativar()
        {
            Ativo = false;
            DataInativacao = DateTime.Now;
        }

        private readonly List<IValidadorDomainCommand<TEntity>> _validacoes = new();
        public IEnumerable<IValidadorDomainCommand<TEntity>> ObterDomainValidadorCommands() {
            if (!_validacoes.Any()) SetValidacoes();
            return _validacoes;
        }
        protected void AddValidacao(IValidadorDomainCommand<TEntity> validacaoCommand) => _validacoes.Add(validacaoCommand);
        protected void AddValidacoes(IEnumerable<IValidadorDomainCommand<TEntity>> validacaoCommand) => _validacoes.AddRange(validacaoCommand);
        protected virtual void SetValidacoes()
        {
            AddValidacao(new ValidarIdCommand<TEntity>((TEntity)this));
        }
    }
}
