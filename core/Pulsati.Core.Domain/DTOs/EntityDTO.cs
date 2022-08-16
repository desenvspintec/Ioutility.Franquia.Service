using Pulsati.Core.Domain.Interfaces.DTOs;

namespace Pulsati.Core.Domain.DTOs
{
    public class EntityDTO : IEntityDTO
    {
        public EntityDTO()
        {

        }

        public EntityDTO(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
