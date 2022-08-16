using Pulsati.Core.Domain.Interfaces.DTOs;

namespace Pulsati.Core.Domain.DTOs
{
    public class EntityBasicDTO : EntityDTO, IEntityBasicDTO
    {
        public EntityBasicDTO() { }

        public EntityBasicDTO(Guid id, string nome) : base(id)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
