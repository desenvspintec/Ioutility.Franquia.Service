namespace Pulsati.Core.Domain.Interfaces.Entitys
{
    public interface IEntity : IMessage, IDisplayNameTypeOf
    {
        DateTime DataCriacao { get; }
        DateTime? DataInativacao { get; }
        bool Ativo { get; }
        void Inativar();
    }
}
