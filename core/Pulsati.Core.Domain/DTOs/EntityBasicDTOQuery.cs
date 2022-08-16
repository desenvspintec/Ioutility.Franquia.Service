using Pulsati.Core.Domain.Interfaces.DTOs;

namespace Pulsati.Core.Domain.DTOs
{
    public class EntityBasicDTOQuery : EntityDTOQuery, IEntityBasicDTO
    {
        public string Nome { get; set; }
    }
}
