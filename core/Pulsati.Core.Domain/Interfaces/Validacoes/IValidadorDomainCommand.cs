using FluentValidation.Results;

namespace Pulsati.Core.Domain.Interfaces.Validacoes
{
    /// <summary>
    /// Interface para entidades de validação em memoria que necessitam do abstract validation
    /// </summary>
    /// <typeparam name="TEntity">Entidade a ser validada</typeparam>   
    public interface IValidadorDomainCommand<TEntity> : IValidacaoCommand<TEntity>
    {
        /// <summary>
        /// metodo responsavel por armazernar o resultado de validação do fluent validation. Para gera-lo, basta usar o metodo validate da classe que herda de AbstractValidator ou CoreDomainValidacaoCommand
        /// </summary>
        /// <returns>resultado de validação exigido pelo fluent validation</returns>
        ValidationResult ValidationResult();
    }
}
