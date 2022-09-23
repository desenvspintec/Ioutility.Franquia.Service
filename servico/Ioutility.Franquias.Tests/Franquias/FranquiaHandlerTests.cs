using Ioutility.Franquias.Domain.Franquias.DTOs;
using Ioutility.Franquias.Domain.Franquias.Interfaces;
using Ioutility.Franquias.Domain.Franquias.Models;
using Ioutility.Franquias.Domain.Franquias.Services;
using Ioutility.Franquias.Tests.Config;
using Ioutility.Franquias.Tests.Testes.Franquias;
using Moq;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Services.Validacao;
using Xunit;

namespace Ioutility.Franquias.Tests.Franquias
{
    public class FranquiaHandlerTests
    {

        private readonly CommandHandlerHelper _helper = CommandHandlerHelper.Obter();
        private readonly FranquiaCommandHandler _commandHandler;

        public FranquiaHandlerTests()
        {
            _commandHandler = new FranquiaCommandHandler(
                _helper.DomainNotification,
                new Mock<IFranquiaRepository>().Object,
                _helper.Mapper,
                new EntityValidacaoService<Franquia>(_helper.DomainNotification),
                _helper.EventStoreService
                );
        }

        [Fact(DisplayName = "1 - Franquia - Map DTO to Domain")]
        [Trait("Categoria", "Franquia Domain 3 - Franquia")]
        public void Map_DTOToDomain_TodasPropriedadesIguais()
        {
            // arrange
            var FranquiaDTO = FranquiaTestsHelper.ObterDTOValido();

            // act
            var Franquia = _helper.Mapper.Map<Franquia>(FranquiaDTO);

            // assert
            DomainIgualDTO(FranquiaDTO, Franquia);

        }

        [Fact(DisplayName = "2 - Franquia - Map Domain to DTO")]
        [Trait("Categoria", "Franqui Domain 3 - Franquia")]
        public void Map_DomainToDTO_TodasPropriedadesIguais()
        {
            // arrange
            var Franquia = _helper.Mapper.Map<Franquia>(FranquiaTestsHelper.ObterDTOValido());

            // act
            var FranquiaDTO = _helper.Mapper.Map<FranquiaDTO>(Franquia);

            // assert
            DomainIgualDTO(FranquiaDTO, Franquia);

        }

        private static void DomainIgualDTO(FranquiaDTO FranquiaDTO, Franquia Franquia)
        {
            Assert.Equal(Franquia.Id, FranquiaDTO.Id);
            Assert.Equal(Franquia.ImagemFranquia, FranquiaDTO.ImagemFranquia);
            Assert.Equal(Franquia.Nome, FranquiaDTO.Nome);
            Assert.Equal(Franquia.Cnpj, FranquiaDTO.Cnpj);
            Assert.Equal(Franquia.ResponsavelLegal, FranquiaDTO.ResponsavelLegal);
            Assert.Equal(Franquia.Email, FranquiaDTO.Email);
            Assert.Equal(Franquia.Telefone, FranquiaDTO.Telefone);
        }

        [Fact(DisplayName = "3 - Franquia - Valido")]
        [Trait("Categoria", "Franqui Domain 3 - Franquia")]
        public async Task EhValido_EstaValido_NaoDeveHaverErrosAsync()
        {
            // arrange
            var FranquiaDTO = FranquiaTestsHelper.ObterDTOValido();

            // act
            await _commandHandler.HandlerRegistrarAsync(FranquiaDTO);

            // assert
            Assert.Empty(_helper.DomainNotification.Obter());
        }

    }
}
