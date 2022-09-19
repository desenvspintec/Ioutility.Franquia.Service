using Ioutility.Franquias.Domain.Procedimentos.DTOs;
using Ioutility.Franquias.Domain.Procedimentos.Interfaces;
using Ioutility.Franquias.Domain.Procedimentos.Models;
using Ioutility.Franquias.Domain.Procedimentos.Services;
using Ioutility.Franquias.Tests.Config;
using Ioutility.Franquias.Tests.Testes.Procedimentos;
using Moq;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Services.Validacao;
using Xunit;

namespace Ioutility.Franquias.Tests.Procedimentos
{
    public class ProcedimentoHandlerTests
    {

        private readonly CommandHandlerHelper _helper = CommandHandlerHelper.Obter();
        private readonly ProcedimentoCommandHandler _commandHandler;

        public ProcedimentoHandlerTests()
        {
            _commandHandler = new ProcedimentoCommandHandler(
                _helper.DomainNotification,
                new Mock<IProcedimentoRepository>().Object,
                _helper.Mapper,
                new EntityValidacaoService<Procedimento>(_helper.DomainNotification),
                _helper.EventStoreService
                );
        }

        [Fact(DisplayName = "1 - Procedimento - Map DTO to Domain")]
        [Trait("Categoria", "Franqui Domain 3 - Procedimento")]
        public void Map_DTOToDomain_TodasPropriedadesIguais()
        {
            // arrange
            var procedimentoDTO = ProcedimentoTestsHelper.ObterDTOValido();

            // act
            var procedimento = _helper.Mapper.Map<Procedimento>(procedimentoDTO);

            // assert
            DomainIgualDTO(procedimentoDTO, procedimento);

        }

        [Fact(DisplayName = "2 - Procedimento - Map Domain to DTO")]
        [Trait("Categoria", "Franqui Domain 3 - Procedimento")]
        public void Map_DomainToDTO_TodasPropriedadesIguais()
        {
            // arrange
            var procedimento = _helper.Mapper.Map<Procedimento>(ProcedimentoTestsHelper.ObterDTOValido());

            // act
            var procedimentoDTO = _helper.Mapper.Map<ProcedimentoDTO>(procedimento);

            // assert
            DomainIgualDTO(procedimentoDTO, procedimento);

        }

        private static void DomainIgualDTO(ProcedimentoDTO procedimentoDTO, Procedimento procedimento)
        {
            Assert.Equal(procedimento.TipoProcedimentoId, procedimentoDTO.TipoProcedimentoId);
            Assert.Equal(procedimento.Especialidade, procedimentoDTO.Especialidade);
            Assert.Equal(procedimento.Id, procedimentoDTO.Id);
            Assert.Equal(procedimento.Valor.Maximo, procedimentoDTO.ValorMaximo);
            Assert.Equal(procedimento.Valor.Minimo, procedimentoDTO.ValorMinimo);
            Assert.Equal(procedimento.Valor.Sugerido, procedimentoDTO.ValorSugerido);
            Assert.Equal(procedimento.Valor.CustoAdicional, procedimentoDTO.ValorCustoAdicional);
            Assert.Equal(procedimento.Comissao.Tipo, procedimentoDTO.ComissaoTipo);
            Assert.Equal(procedimento.Comissao.Valor, procedimentoDTO.ComissaoValor);
        }

        [Fact(DisplayName = "3 - Procedimento - Valido")]
        [Trait("Categoria", "Franqui Domain 3 - Procedimento")]
        public async Task EhValido_EstaValido_NaoDeveHaverErrosAsync()
        {
            // arrange
            var procedimentoDTO = ProcedimentoTestsHelper.ObterDTOValido();

            // act
            await _commandHandler.HandlerRegistrarAsync(procedimentoDTO);

            // assert
            Assert.Empty(_helper.DomainNotification.Obter());
        }
        [Fact(DisplayName = "4 - Procedimento - Invalido - Limites maximo estourados e comissao fixa")]
        [Trait("Categoria", "Franqui Domain 3 - Procedimento")]
        public async Task EhValido_Invalido_DeveHaverErrosLimitesMaximosAsync()
        {
            // arrange
            var procedimentoDTOInvalidoLimitesMaximosEstouradosComissaoFixa = ProcedimentoTestsHelper.ObterDTOInvalidoLimitesMaximosEstouradosComissaoFixa();

            // act
            await _commandHandler.HandlerRegistrarAsync(procedimentoDTOInvalidoLimitesMaximosEstouradosComissaoFixa);

            // assert
            var erros = _helper.DomainNotification.Obter();
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMaximo("Valor da Comissão", 99999.0)));
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMaximo("Valor Mínimo", 99999.0)));
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMaximo("Valor Máximo", 99999.0)));
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMaximo("Valor Sugerido", procedimentoDTOInvalidoLimitesMaximosEstouradosComissaoFixa.ValorMaximo)));
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMaximo("Custos Adicionais", 99999.0)));
        }

        [Fact(DisplayName = "5 - Procedimento - Invalido - Valor minimo nao pode ser maior que valores maximmo e segerido")]
        [Trait("Categoria", "Franqui Domain 3 - Procedimento")]
        public async Task EhValido_Invalido_ValorMinimoNaoPodeMaiorQueDemaisValores()
        {
            // arrange
            var procedimentoDTO = ProcedimentoTestsHelper.ObterDTOValido();
            procedimentoDTO.ValorMinimo += 10;

            // act
            await _commandHandler.HandlerRegistrarAsync(procedimentoDTO);

            // assert
            var erros = _helper.DomainNotification.Obter();
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMinimo("Valor Sugerido", 11)));
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMinimo("Valor Máximo", 11)));
        }

        [Fact(DisplayName = "6 - Procedimento - Invalido - Limites minimos estourados e comissao fixa")]
        [Trait("Categoria", "Franqui Domain 3 - Procedimento")]
        public async Task EhValido_Invalido_DeveHaverErrosLimitesMinimosAsync()
        {
            // arrange
            var procedimentoDTO = ProcedimentoTestsHelper.ObterDTOInvalidoLimitesMinimosEstouradosComissaoFixa();
            procedimentoDTO.ValorMaximo = procedimentoDTO.ValorMinimo - 1;
            procedimentoDTO.ValorSugerido = procedimentoDTO.ValorMinimo - 1;
            // act
            await _commandHandler.HandlerRegistrarAsync(procedimentoDTO);

            // assert
            var erros = _helper.DomainNotification.Obter();
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMinimo("Valor da Comissão", 0)));
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMinimo("Valor Mínimo", 0)));
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMinimo("Valor Máximo", procedimentoDTO.ValorMinimo)));
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMinimo("Valor Sugerido", procedimentoDTO.ValorMinimo)));
            Assert.Contains(erros, erro => erro.Notificacao.Contains(MensagemErroHelper.NumeroMinimo("Custos Adicionais", 0)));
        }
    }
}
