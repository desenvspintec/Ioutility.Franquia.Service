namespace Pulsati.Core.Domain.Interfaces.DTOs
{
    public interface IEntityDTO : IMessage
    {
        new Guid Id { get; set; }
    }
}
