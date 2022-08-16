namespace Pulsati.Core.Domain.Interfaces.Entitys
{
    public interface IEntityBasic : IEntity
    {
        string Nome { get; }
        string NomeQuery { get; }
        string NomeSemPreposicaoQuery { get; }

    }
}
