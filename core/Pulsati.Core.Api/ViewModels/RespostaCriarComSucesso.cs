using Pulsati.Core.Domain.Interfaces.DTOs;

namespace Pulsati.Core.Api.ViewModels
{
    public class RespostaCriarComSucesso
    {
        public RespostaCriarComSucesso()
        {

        }
        public RespostaCriarComSucesso(Guid id)
        {
            Id = id;
        }
        public RespostaCriarComSucesso(IEntityDTO entityDto)
        {
            Id = entityDto.Id;
        }

        public Guid Id { get; }
    }
}