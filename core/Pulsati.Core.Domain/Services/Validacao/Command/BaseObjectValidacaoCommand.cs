using FluentValidation;
using FluentValidation.Results;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Interfaces.Validacoes;
using Pulsati.Core.Domain.Models;
using Pulsati.Core.Domain.Services.Validacao.DTOs;
using System.Linq.Expressions;

namespace Pulsati.Core.Domain.Services.Validacao.Command
{
    public abstract class BaseObjectValidacaoCommand<TEntity> : AbstractValidator<TEntity>, IValidadorDomainCommand<TEntity>
    {
        
        protected readonly TEntity _entity;
        protected ValidationResult _validationResult = new();
        protected ValidationResult _validationResultDependente = new();

        protected BaseObjectValidacaoCommand(TEntity entity)
        {
            _entity = entity;
            PreencherRegrasValidacao();

        }
        public ValidationResult ValidationResult() => _validationResult;
        public abstract void PreencherRegrasValidacao();

        public Task<ResultadoValidacao> ValidarAsync(TEntity entity)
        {
            _preencherValidationResult();
            if (_validationResult.IsValid)
                return Task.FromResult(ResultadoValidacao.ObterValido());
            var erros = _validationResult.Errors.Select(erro => erro.PropertyName + "||" +  erro.ErrorMessage + "||" + erro.AttemptedValue);
            return Task.FromResult(ResultadoValidacao.ObterComErros(erros));
        }

        protected void _preencherValidationResult()
        {
            _validationResult = Validate(_entity);
            _validationResult.Errors.AddErrors(_validationResultDependente.Errors);
        }

        protected virtual void ValidarCampoObrigatorio<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionPropriedade, string nomePropriedade = "")
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .NotEmpty()
                .WithMessage(MensagemErroHelper.NaoNulo(nomePropriedade));

            var tipo = typeof(TPropertyReturn);
            var ehGuid = (tipo.FullName.Contains("System.Guid") && (tipo.FullName.Contains("System.Nullable") || tipo.Name == "Guid"));
            if (ehGuid)
            {
                var guidValidar = expressionPropriedade.Compile().Invoke(_entity) as Guid?;
                Expression<Func<TEntity, Guid?>> expressionGuid = entity => guidValidar;
                RuleFor(expressionGuid).SetValidator(new GuidEmptyValidacaoHelper(nomePropriedade));
            }
        }

        protected virtual void ValidarCampoDeveSerNulo<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionPropriedade, string nomePropriedade = "")
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .Null()
                .WithMessage(MensagemErroHelper.DeveSerNulo(nomePropriedade));

        }
        protected virtual void ValidarCampoDeveSerVazio<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionPropriedade, string nomePropriedade = "")
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .Empty()
                .WithMessage(MensagemErroHelper.DeveSerNulo(nomePropriedade));
        }
        protected virtual void ValidarIntervaloNumerico(Expression<Func<TEntity, int?>> expressionPropriedade, int maximo, int minimo = 0, string nomePropriedade = "")
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .GreaterThanOrEqualTo(minimo)
                .WithMessage(MensagemErroHelper.NumeroMinimo(nomePropriedade, minimo))
                .LessThanOrEqualTo(maximo)
                .WithMessage(MensagemErroHelper.NumeroMaximo(nomePropriedade, maximo));
        }
        protected virtual void ValidarIntervaloNumerico(Expression<Func<TEntity, double?>> expressionPropriedade, double maximo, double minimo = 0, string nomePropriedade = "")
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .GreaterThanOrEqualTo(minimo)
                .WithMessage(MensagemErroHelper.NumeroMinimo(nomePropriedade, minimo))
                .LessThanOrEqualTo(maximo)
                .WithMessage(MensagemErroHelper.NumeroMaximo(nomePropriedade, maximo));
        }
        protected string _obterNomePropriedadeParaValidacao<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionPropriedade, string propriedade)
        {
            if (string.IsNullOrEmpty(propriedade))
                return _obterNomeDePropriedadeEmExpression(expressionPropriedade);
            return propriedade;
        }

        private string _obterNomeDePropriedadeEmExpression<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionPropriedade)
        {
            var expressionString = expressionPropriedade.ToString();
            var nomePropriedade = expressionString.Split('.').Last();
            return nomePropriedade;
        }

        protected void ValidarCampoTamanhoMinimo(Expression<Func<TEntity, string>> expressionPropriedade, string nomePropriedade = "", int tamanho = Constante.MIN_LEN_PADRAO)
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .MinimumLength(tamanho)
                .WithMessage(MensagemErroHelper.MinLength(nomePropriedade, tamanho));
        }
        protected void ValidarCampoTamanhoMaximo(Expression<Func<TEntity, string>> expressionPropriedade, string nomePropriedade = "", int tamanho = Constante.MAX_LEN_PADRAO)
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .MaximumLength(tamanho)
                .WithMessage(MensagemErroHelper.MaxLength(nomePropriedade, tamanho));
        }

        protected virtual void ValidarCampoTextoBasico(Expression<Func<TEntity, string>> expressionPropriedade, string nomePropriedade = "", bool obrigatorio = true, int tamanhoMaximo = Constante.MAX_LEN_PADRAO, int tamanhoMinimo = Constante.MIN_LEN_PADRAO)
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            if (obrigatorio)
                ValidarCampoObrigatorio(expressionPropriedade, nomePropriedade);

            ValidarCampoTamanhoMinimo(expressionPropriedade, nomePropriedade, tamanhoMinimo);
            ValidarCampoTamanhoMaximo(expressionPropriedade, nomePropriedade, tamanhoMaximo);
        }
        protected void ValidarDataMinimaAtual(Expression<Func<TEntity, DateTime>> expressionPropriedade, string nomePropriedade = "")
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .GreaterThanOrEqualTo(Constante.DATA_ATUAL)
                .WithMessage(MensagemErroHelper.DataMaiorQue(nomePropriedade, Constante.DATA_ATUAL));
        }
        protected void ValidarDataMaximaAtual(Expression<Func<TEntity, DateTime>> expressionPropriedade, string nomePropriedade = "")
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .LessThanOrEqualTo(Constante.DATA_ATUAL)
                .WithMessage(MensagemErroHelper.DataMenorQue(nomePropriedade, Constante.DATA_ATUAL));
        }

        protected void ValidarDataMaxima(Expression<Func<TEntity, DateTime>> expressionPropriedade, DateTime limite, string nomePropriedade = "")
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .LessThanOrEqualTo(limite)
                .WithMessage(MensagemErroHelper.DataMenorQue(nomePropriedade, limite));
        }
        protected void ValidarEmail(Expression<Func<TEntity, string>> expressionPropriedade, string nomePropriedade = "")
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .EmailAddress()
                .WithMessage(MensagemErroHelper.EmailNaoValido(nomePropriedade));
        }
        protected void ValidarDataCoerente(Expression<Func<TEntity, DateTime>> expressionPropriedade, string nomePropriedade = "", DateTime? dataMinima = null)
        {

            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            var dataMinimaUtilizar = dataMinima ?? Constante.DATA_MINIMA_PARA_SER_CORENTE;

            RuleFor(expressionPropriedade)
                .GreaterThanOrEqualTo(dataMinimaUtilizar)
                .WithMessage(MensagemErroHelper.DataMaiorQue(nomePropriedade, dataMinimaUtilizar));
        }
        protected void ValidarDocumento(Expression<Func<TEntity, ValidaroDocumentoDTO>> expressionPropriedade, string formControlName, string nomePropriedade)
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            RuleFor(expressionPropriedade)
                .Must(documento =>
                {
                    switch (documento.Tipo)
                    {
                        case Enums.ETipoDocumentoRegistroFederal.CertidaoNascimento:
                            return true;
                        case Enums.ETipoDocumentoRegistroFederal.Cnpj:
                            return ValidacaoHelper.Cnpj(documento.Numero);
                        case Enums.ETipoDocumentoRegistroFederal.Sei:
                            return true;
                        default:
                            break;
                    }
                    return true;
                })
                .OverridePropertyName(formControlName)
                .WithMessage(MensagemErroHelper.NumeroDocumento());
        }
        protected void ValidarListaDependente<TEntityValidate>(Expression<Func<TEntity, IEnumerable<TEntityValidate>>> expressionListaPropriedade
                , string nomePropriedade = ""
                , bool listaObrigatoria = true) where TEntityValidate : IObjectComDomainValidacao<TEntityValidate>
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionListaPropriedade, nomePropriedade);

            if (listaObrigatoria)
                ValidarCampoObrigatorio(expressionListaPropriedade, nomePropriedade);

            var dependentes = expressionListaPropriedade.Compile().Invoke(_entity);
            if (dependentes == null)
                return;

            foreach (var dependente in dependentes)
            {
                var validadoresDependente = dependente.ObterDomainValidadorCommands();
                foreach (var validadorDependente in validadoresDependente)
                    _addErrorDeEntityDependente(dependente, validadorDependente);
            }

        }

        protected void _addErrorDeEntityDependente<TEntityValidate>(TEntityValidate dependente, IValidadorDomainCommand<TEntityValidate> validadorDependente) where TEntityValidate : IObjectComDomainValidacao<TEntityValidate>
        {
            var resultadoValidacao = validadorDependente.ValidarAsync(dependente).Result;
            if (!resultadoValidacao.EstaValido)
                _validationResultDependente.Errors.AddErrors(validadorDependente.ValidationResult().Errors);
        }


        protected void ValidarEntityDependente<TEntityValidate>(Expression<Func<TEntity, TEntityValidate?>> expressionPropriedade, string nomePropriedade = "", bool dependenteObrigatorio = true) where TEntityValidate : IObjectComDomainValidacao<TEntityValidate>
        {
            nomePropriedade = _obterNomePropriedadeParaValidacao(expressionPropriedade, nomePropriedade);
            if (dependenteObrigatorio)
            {
                ValidarCampoObrigatorio(expressionPropriedade, nomePropriedade);
            }

            var dependente = expressionPropriedade.Compile().Invoke(_entity);
            if (dependente.EstaNulo()) return;

            var validadoresDependente = dependente.ObterDomainValidadorCommands();
            foreach (var validadorDependente in validadoresDependente)
                _addErrorDeEntityDependente(dependente, validadorDependente);


        }
        protected void ValidarListaDependenteDuplicada(Expression<Func<TEntity, IEnumerable<string>>> expressionObterListaComForeingKey
               , string nomePropriedade
               )
        {
            RuleFor(expressionObterListaComForeingKey)
                .Must(foreingKeys => !foreingKeys
                    .Any(foreingKeyVerificar => foreingKeys.Count(foreingKeyDaLista => foreingKeyVerificar == foreingKeyDaLista) > 1))
                .WithMessage(MensagemErroHelper.ListaRepetida(nomePropriedade));
        }
        protected void ValidarListaDependenteDuplicada(Expression<Func<TEntity, IEnumerable<Guid>>> expressionObterListaComForeingKey
                , string nomePropriedade
                )
        {
            try
            {
                var lista = expressionObterListaComForeingKey.Compile().Invoke(_entity);
                if (lista == null) return;
            }
            catch
            {
                // seguindo os principios do SOLID - SRP, este metodo apenas verifica se a lista esta duplicada
                // e nao se ela esta preenchida, logo, uma vez que ela não esta preenchida, o metodo pode finalizar
                // pois com certeza não esta duplicada.
                // Att Cassiano Garcia Nunes - 23/03/2020.
                return;
            }
            RuleFor(expressionObterListaComForeingKey)
                .Must(foreingKeys => !foreingKeys
                    .Any(foreingKeyVerificar => foreingKeys.Count(foreingKeyDaLista => foreingKeyVerificar == foreingKeyDaLista) > 1))
                .WithMessage(MensagemErroHelper.ListaRepetida(nomePropriedade));
        }
    }
}
