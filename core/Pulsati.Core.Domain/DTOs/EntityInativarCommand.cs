namespace Pulsati.Core.Domain.DTOs
{
    public class EntityInativarCommand
    {
        public EntityInativarCommand()
        {

        }
        public EntityInativarCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
