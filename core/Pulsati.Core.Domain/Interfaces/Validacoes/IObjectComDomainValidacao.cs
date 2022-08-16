namespace Pulsati.Core.Domain.Interfaces.Validacoes
{
    public interface IObjectComDomainValidacao<TEntity>
    {
        IEnumerable<IValidadorDomainCommand<TEntity>> ObterDomainValidadorCommands();

    }
}
